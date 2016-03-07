function View(style, roomColor, siUnit, sensorValues) {
    this.style = style;
    this.roomColor = roomColor;
    this.siUnit = siUnit;
    this.sensorValues = sensorValues;

    this.roomGeoJson = null;

    View.prototype.drawView = function () {
        View.prototype.removeView.call();

        function onSuccess(response) {
            View.roomGeoJson = L.geoJson(jQuery.parseJSON(response), {
                style: style,
                onEachFeature: onEachFeature
            });
            geoMap.addLayer(View.roomGeoJson);
        }

        PageMethods.DrawFloor(currentFloorLevel, onSuccess);

        
    };

    View.prototype.cleanup = function () {
        this.removeView();
        this.removeLegend();
    }

    View.prototype.removeLegend = function () {
        if (View.legend != null) {
            geoMap.removeControl(View.legend);
        }
    }

    View.prototype.removeView = function () {
        if (View.roomGeoJson != null) {
            geoMap.removeLayer(View.roomGeoJson);
        }
    }

    /* This function is used for creating and updating the legend on the map
* @param {} grade collections of items to use in the legend
* @param {} coloring the collering for the items, this must be a function
* @param {} siUnit the unit for all the items
*/
    View.prototype.drawLegend = function () {
        View.legend = L.control({ position: 'bottomright' });
        View.legend.onAdd = function (map) {

            //Creates the div for the legend
            var div = L.DomUtil.create('div', 'info legend');
            // loop through our density intervals and generate a label with a colored square for each interval
            for (var i = 0; i < sensorValues.length; i++) {
                div.innerHTML +=
                    '<i style="background:' + roomColor(sensorValues[i]) + '"></i> ' +
                    sensorValues[i] + (sensorValues[i + 1] ? siUnit + '<br>' : siUnit);
            }
            return div;
        };


        View.legend.addTo(geoMap);
    }

}