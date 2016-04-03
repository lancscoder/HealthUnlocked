var Weather = React.createClass({
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
        return (
            <div className="row">
                {this.state.forecasts.map(function (forecast, i) {
                     return (
                <div className="col-md-3" key={i}>
                    <h2>{forecast.Day}</h2>
                    <p>{forecast.Description}</p>
                    <p>High {forecast.High}&deg;&nbsp;                        
                    {(() => {
                        if (forecast.High > this.state.highAverage) {
                            return "+" + (forecast.High - this.state.highAverage);
                        }
                        if (forecast.High < this.state.highAverage) {
                            return "-" + (this.state.highAverage - forecast.High);
                        }
                        return "";
                    })()}
                        </p>
                    <p>Low {forecast.Low}&deg;&nbsp;                       
                    {(() => {
                        if (forecast.Low > this.state.lowAverage) {
                            return "+" + (forecast.Low - this.state.lowAverage);
                        }
                        if (forecast.Low < this.state.lowAverage) {
                            return "-" + (this.state.lowAverage - forecast.Low);
                        }
                        return "";
                    })()}
                        </p>
                </div>
                );
                 }.bind(this))}
            </div>
      );
    }
});

ReactDOM.render(
  <Weather source="/api/weather/forecast/london" />,
  document.getElementById('weather')
);