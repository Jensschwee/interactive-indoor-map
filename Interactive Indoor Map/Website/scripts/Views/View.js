function View(style, roomColor, siUnit, sensorValues) {
    this.style = style;
    this.roomColor = roomColor;
    this.siUnit = siUnit;
    this.sensorValues = sensorValues;
    this.roomGeoJson = null;


    View.drawView = function() {
        this.removeView();

        //console.log(View.style);

        function onSuccess(response) {
            View.roomGeoJson = L.geoJson(jQuery.parseJSON(response), {
                style: View.style,
                onEachFeature: onEachFeature
            });
            geoMap.addLayer(View.roomGeoJson);
        }

        PageMethods.DrawFloor(currentFloorLevel, onSuccess);

        if (isFloorInfoToggled) {
            onFloorInfoUpdate();
        }
    };

    //set style(value) {
    //    //console.log("1");
    //    this.style = value;
    //}

    //changeFloor(floorLevel) {
    //    removeView();

    //    function onSuccess(response, userContext, methodName) {
    //        drawView(response);
    //    }

    //    PageMethods.DrawFloor(floorLevel, onSuccess);

    //    if (isFloorInfoToggled) {
    //        onFloorInfoUpdate();
    //    }
    //}

    View.cleanup = function () {
        this.removeView();
        this.removeLegend();
    }

    View.removeLegend = function() {
        if (View.legend != null) {
            geoMap.removeControl(View.legend);
        }
    }
    View.removeView = function() {
        if (View.roomGeoJson != null) {
            geoMap.removeLayer(View.roomGeoJson);
        }
    }

    /* This function is used for creating and updating the legend on the map
* @param {} grade collections of items to use in the legend
* @param {} coloring the collering for the items, this must be a function
* @param {} siUnit the unit for all the items
*/
    View.drawLegend = function() {
        this.removeLegend();

        View.legend = L.control({ position: 'bottomright' });


        View.legend.onAdd = function (map) {
            //Creates the div for the legend
            var div = L.DomUtil.create('div', 'info legend');

            // loop through our density intervals and generate a label with a colored square for each interval
            for (var i = 0; i < View.sensorValues.length; i++) {
                div.innerHTML +=
                    '<i style="background:' + View.roomColor(View.sensorValues[i]) + '"></i> ' +
                    View.sensorValues[i] + (View.sensorValues[i + 1] ? View.siUnit + '<br>' : View.siUnit);
            }
            return div;
        };


        View.legend.addTo(geoMap);
    }

}