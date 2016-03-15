var legendArray = new Array();

function drawLegend() {
    var activeViews = ViewStates.ActiveViews;
    if (activeViews != 0) {
        d3.select("#legend").select("svg").remove();
        d3.select("#legend").select("div").remove();
        var imageStartPos = 45;
        if (activeViews === 2) {
            imageStartPos = 15;
        }
        else if (activeViews === 3) {
            imageStartPos = 7;
        }
        else if (activeViews === 4) {
            imageStartPos = 4;
        }

        for (var i = 0; i < activeViews; i++) {
            var legendItem = selectLegendItem(i);
            d3.select("#legend")
             .append("svg")
              .attr("width", 100 / activeViews + '%')
              .attr("height", '100%')
              .append("rect")
              .attr("width", 100 + '%')
              .attr("height", 100 + '%')
              .style("fill", legendItem.color);

            d3.select("#legend")
                .append('div')
                .attr("class", 'IconImage')
                .attr("style", 'top: 42%; left:' + (100 / activeViews * i + imageStartPos) +  '%')
                .append('img')
                .attr("width", 25)
                .attr("height", 25)
                .attr("src", legendItem.icon);

        }
    }
}

function selectLegendItem(i) {
    var counter = i;
    var legendItem = {
        color: '',
        icon: ''
    };
    if (ViewStates.Temperature) {
        if (counter === 0) {
            legendItem.color = ViewStates.TemperatureColor;
            legendItem.icon = 'Images/temperatureIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.CO2) {
        if (counter === 0) {
            legendItem.color = ViewStates.CO2Color;
            legendItem.icon = 'Images/co2icon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Light) {
        if (counter === 0) {
            legendItem.color = ViewStates.LightColor;
            legendItem.icon = 'Images/lightIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.HardwareConsumption) {
        if (counter === 0) {
            legendItem.color = ViewStates.HardWareConsumptionColor;
            legendItem.icon = 'Images/hardwarePowerIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.LightConsumption) {
        if (counter === 0) {
            legendItem.color = ViewStates.LightConsumptionColor;
            legendItem.icon = 'Images/LightPowerIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.VentilationConsumption) {
        if (counter === 0) {
            legendItem.color = ViewStates.VentilationConsumptionColor;
            legendItem.icon = 'Images/ventilationPowerIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.OtherConsumption) {
        if (counter === 0) {
            legendItem.color = ViewStates.OtherConsumptionColor;
            legendItem.icon = 'Images/otherPowerIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.TotalPowerConsumption) {
        if (counter === 0) {
            legendItem.color = ViewStates.TotalPowerConsumptionColor;
            legendItem.icon = 'Images/totalPowerIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Motion) {
        if (counter === 0) {
            legendItem.color = ViewStates.MotionColor;
            legendItem.icon = 'Images/motionIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Occupants) {
        if (counter === 0) {
            legendItem.color = ViewStates.OccupantsColor;
            legendItem.icon = 'Images/occupantsIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.WifiClients) {
        if (counter === 0) {
            legendItem.color = ViewStates.WifiClientsColor;
            legendItem.icon = 'Images/wifiIcon.png';
            return legendItem;
        } else 
            counter--;
    }

}





