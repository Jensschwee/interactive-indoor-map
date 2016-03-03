"use strict";
class View {

    constructor(style, roomColor, siUnit, sensorValues) {
        this.roomGeoJson = "";
        this.style = style;
        this.roomColor = roomColor;
        this.siUnit = siUnit;
        this.sensorValues = sensorValues;
    }

    

    drawView() {
        console.log(this.style);
        this.removeView();

        function onSuccess(response, userContext, methodName) {
            this.roomGeoJson = L.geoJson(jQuery.parseJSON(response), {
                style: getStyle(),
                onEachFeature: onEachFeature
            });
        }

        PageMethods.DrawFloor(currentFloorLevel, onSuccess);

        if (isFloorInfoToggled) {
            onFloorInfoUpdate();
        }

        geoMap.addLayer(this.geojson);
    }

    getStyle() {
        return this.style;
    }

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

    cleanup() {
        this.removeView();
        this.removeLegend();
    }

    removeLegend() {
        if (this.legend != null) {
            geoMap.removeControl(this.legend);
        }
    }
    removeView() {
        if (geoMap != null) {
            geoMap.removeLayer(this.roomGeoJson);
        }
    }

    /* This function is used for creating and updating the legend on the map
* @param {} grade collections of items to use in the legend
* @param {} coloring the collering for the items, this must be a function
* @param {} siUnit the unit for all the items
*/
    drawLegend() {
        removeLegend();

        this.legend = L.control({ position: 'bottomright' });

        this.legend.onAdd = function (map) {
            //Creates the div for the legend
            var div = L.DomUtil.create('div', 'info legend');

            // loop through our density intervals and generate a label with a colored square for each interval
            for (var i = 0; i < this.sensorValues.length; i++) {
                div.innerHTML +=
                    '<i style="background:' + this.roomColor(this.sensorValues[i]) + '"></i> ' +
                    this.sensorValues[i] + (this.sensorValues[i + 1] ? this.siUnit + '<br>' : this.siUnit);
            }
            return div;
        };

        this.legend.addTo(geoMap);
    }

}