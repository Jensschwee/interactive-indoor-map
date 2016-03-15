var legendArray = new Array();

function drawLegend() {
    var viewCount = ViewStates.ActiveViews;
    if (viewCount != 0) {
        d3.select("#legend").select("svg").remove();

        for (var i = 0; i < viewCount; i++) {
            //legendArray[i].width = 100 / viewCount;
            //legendArray[i].height = 10;
            //legendArray[i].fill = 'red';

            d3.select("#legend")
             .append("svg")
              .attr("width", 100 / viewCount + '%')
              .attr("height", '100%')
              .append("rect")
              .attr("width", 100 + '%')
              .attr("height", 100 + '%')
              .style("fill", selectColors(i));
        }
    }
}

function selectColors(i) {
    var counter = i;

    if (ViewStates.Temperature) {
        if (counter === 0) {
            return 'Blue';
        } else
            counter--;
    }

    if (ViewStates.CO2) {
        if (counter === 0) {
            return 'red';
        } else
            counter--;
    }

    if (ViewStates.Light) {
        if (counter === 0) {
            return 'Green';
        } else
            counter--;
    }

    if (ViewStates.HardwareConsumption) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.VentilationConsumption) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.OtherConsumption) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.LightConsumption) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.Motion) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.Occupants) {
        if (counter === 0) {
            return 'FFFFFF';
        } else
            counter--;
    }

    if (ViewStates.WifiClients) {
        if (counter === 0) {
            return 'FFFFFF';
        }
    }

}





