var Weather = React.createClass({
    displayName: "Weather",

    getInitialState: function () {
        return {
            forecasts: [],
            highAverage: 0,
            lowAverage: 0
        };
    },

    componentDidMount: function () {
        this.serverRequest = $.get(this.props.source, function (result) {
            this.setState({
                forecasts: result.forecast,
                highAverage: result.highAverage,
                lowAverage: result.lowAverage
            });
        }.bind(this));
    },

    componentWillUnmount: function () {
        this.serverRequest.abort();
    },

    render: function () {
        return React.createElement(
            "div",
            { className: "row" },
            this.state.forecasts.map(function (forecast, i) {
                return React.createElement(
                    "div",
                    { className: "col-md-3", key: i },
                    React.createElement(
                        "h2",
                        null,
                        forecast.Day
                    ),
                    React.createElement(
                        "p",
                        null,
                        forecast.Description
                    ),
                    React.createElement(
                        "p",
                        null,
                        "High ",
                        forecast.High,
                        "° ",
                        (() => {
                            if (forecast.High > this.state.highAverage) {
                                return "+" + (forecast.High - this.state.highAverage);
                            }
                            if (forecast.High < this.state.highAverage) {
                                return "-" + (this.state.highAverage - forecast.High);
                            }
                            return "";
                        })()
                    ),
                    React.createElement(
                        "p",
                        null,
                        "Low ",
                        forecast.Low,
                        "° ",
                        (() => {
                            if (forecast.Low > this.state.lowAverage) {
                                return "+" + (forecast.Low - this.state.lowAverage);
                            }
                            if (forecast.Low < this.state.lowAverage) {
                                return "-" + (this.state.lowAverage - forecast.Low);
                            }
                            return "";
                        })()
                    )
                );
            }.bind(this))
        );
    }
});

ReactDOM.render(React.createElement(Weather, { source: "/api/weather/forecast/london" }), document.getElementById('weather'));