var legendArray = new Array();

function drawLegend() {
    var activeViews = ViewStates.ActiveViews;
    if (activeViews != 0) {
        d3.select("#legend").select("svg").remove();
        d3.select("#legend").select("img").remove();

        for (var i = 0; i < activeViews; i++) {
            //legendArray[i].width = 100 / viewCount;
            //legendArray[i].height = 10;
            //legendArray[i].fill = 'red';
            var legendItem = selectLegendItem(i);
            d3.select("#legend")
             .append("svg")
              .attr("width", 100 / activeViews + '%')
              .attr("height", '100%')
              .append("rect")
              .attr("width", 100 + '%')
              .attr("height", 100 + '%')
              .style("fill", legendItem.coler);

            d3.select("#legend")
                .append('div')
                .attr("class", 'IconImage')
                //.attr("style", 'top: 42%; left:' + 100 / activeViews * i + '%')
                .attr("style", 'top: 42%; left: 45%')
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
        coler: '',
        icon: ''
    };
    if (ViewStates.Temperature) {
        if (counter === 0) {
            legendItem.coler = 'Blue';
            legendItem.icon = 'Images/temperatureIcon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.CO2) {
        if (counter === 0) {
            legendItem.coler = 'red';
            legendItem.icon = 'Images/co2icon.png';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Light) {
        if (counter === 0) {
            legendItem.coler = 'Green';

            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.HardwareConsumption) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.VentilationConsumption) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.OtherConsumption) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.LightConsumption) {
        if (counter === 0) {
            legendItem.coler = 'Green';

            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Motion) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.Occupants) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        } else
            counter--;
    }

    if (ViewStates.WifiClients) {
        if (counter === 0) {
            legendItem.coler = 'Green';
            return legendItem;
        }
    }

}





