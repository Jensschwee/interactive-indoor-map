var legendArray = new Array();

function drawLegend() {
    var activeViews = ActiveViews.length;
    d3.select("#legend").selectAll("svg").remove();
    d3.select("#legend").selectAll("div").remove();
    if (activeViews != 0) {
        var imageStartPos = 43;
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
            d3.select("#legend")
             .append("svg")
              .attr("width", 100 / activeViews + '%')
              .attr("height", '100%')
              .append("rect")
              .attr("width", 100 + '%')
              .attr('stroke-width', 1)
              .attr('stroke', 'rgb(0,0,0)')
              .attr("height", 100 + '%')
              .style("fill", ActiveViews[i].color);

            d3.select("#legend")
                .append('div')
                .attr("class", 'IconImage')
                .attr("style", 'top: 42%; left:' + (100 / activeViews * i + imageStartPos) +  '%')
                .append('img')
                .attr("width", 25)
                .attr("height", 25)
                .attr("src", ActiveViews[i].icon);

        }
    }
}

//function selectLegendItem(i) {
//    var counter = i;
//    var legendItem = {
//        color: '',
//        icon: '',
//        max: 'CO2Max',
//        value: 'CO2'
//    };
//    if (ActiveViews.Temperature) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.TemperatureColor;
//            legendItem.icon = 'Images/temperatureIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.CO2) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.CO2Color;
//            legendItem.icon = 'Images/co2icon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.Light) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.LightColor;
//            legendItem.icon = 'Images/lightIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.TotalPowerConsumption) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.TotalPowerConsumptionColor;
//            legendItem.icon = 'Images/totalPowerIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.HardwareConsumption) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.HardWareConsumptionColor;
//            legendItem.icon = 'Images/hardwarePowerIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.LightConsumption) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.LightConsumptionColor;
//            legendItem.icon = 'Images/LightPowerIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.VentilationConsumption) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.VentilationConsumptionColor;
//            legendItem.icon = 'Images/ventilationPowerIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.OtherConsumption) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.OtherConsumptionColor;
//            legendItem.icon = 'Images/otherPowerIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.Motion) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.MotionColor;
//            legendItem.icon = 'Images/motionIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.Occupants) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.OccupantsColor;
//            legendItem.icon = 'Images/occupantsIcon.png';
//            return legendItem;
//        } else
//            counter--;
//    }

//    if (ActiveViews.WifiClients) {
//        if (counter === 0) {
//            legendItem.color = ActiveViews.WifiClientsColor;
//            legendItem.icon = 'Images/wifiIcon.png';
//            return legendItem;
//        } else 
//            counter--;
//    }

//}





