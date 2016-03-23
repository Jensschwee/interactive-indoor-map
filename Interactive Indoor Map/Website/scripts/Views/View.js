function View(style, roomColor, siUnit, sensorValues) {
    this.style = style;
    this.roomColor = roomColor;
    this.siUnit = siUnit;
    this.sensorValues = sensorValues;

    this.roomGeoJson = null;

    View.prototype.drawView = function () {
        View.prototype.removeView.call();

        function onSuccess(response) {

            var collection = JSON.parse(response);
            var column = new Array();
            for (var j = 0; j < ViewStates.ActiveViews; j++) {
                var features = new Array();
                var jsonColumn = {
                    type: "FeatureCollection",
                    features: features
                };
                $.each(collection.features, function (index, value) {

                    var coordinate = new Array();
                    var coordinates = new Array();
                    coordinate.push(coordinates);
                    var geometry =
                        {
                            type: "Polygon",
                            coordinates: coordinate
                        };
                    var feature = {
                        type: "Feature",
                        geometry: geometry,
                        properties: value.properties
                    }
                    //bottomRightVertex
                    var D = value.geometry.coordinates[0][3];
                    //bottomLeftVertex
                    var A = value.geometry.coordinates[0][2];

                    ////topRightVertex
                    var C = value.geometry.coordinates[0][0];
                    ////topLeftVertex
                    var B = value.geometry.coordinates[0][1];

                    var minValue = 0;
                    var maxValue = 5;
                    var sensorValue = 2.5;

                    var point = [];
                    //Col A X
                    point.push(A[0] + ((D[0] - A[0]) / ViewStates.ActiveViews) * j);
                    //Col A y
                    point.push(A[1] + ((D[1] - A[1]) / ViewStates.ActiveViews) * j);


                    coordinates.push(point);

                    point = [];
                    //Col D X
                    point.push(A[0] + ((D[0] - A[0]) / ViewStates.ActiveViews) * (j + 1));

                    //Col D y
                    point.push(A[1] + ((D[1] - A[1]) / ViewStates.ActiveViews) * (j + 1));

                    coordinates.push(point);
                    point = [];
                    //Col C X
                    point.push(B[0] + ((C[0] - B[0]) / ViewStates.ActiveViews) * (j + 1) - ((B[0] - A[0]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

                    //Col C y
                    point.push(B[1] + ((C[1] - B[1]) / ViewStates.ActiveViews) * (j + 1) - ((B[1] - A[1]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

                    coordinates.push(point);

                    point = [];
                    //Col B X
                    point.push(B[0] + ((C[0] - B[0]) / ViewStates.ActiveViews) * (j) - ((B[0] - A[0]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

                    //Col B y
                    point.push(B[1] + ((C[1] - B[1]) / ViewStates.ActiveViews) * (j) - ((B[1] - A[1]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

                    coordinates.push(point);

                    coordinates.push(coordinates[0]);

                    features.push(feature);

                });
                column.push(jsonColumn);
            }

            for (var i = 0; i < ViewStates.ActiveViews; i++) {
                var roomColumn = column.shift();

                var svg = d3.select(geoMap.getPanes().overlayPane).append("svg"),
               g = svg.append("g").attr("class", "leaflet-zoom-hide");

                var transform = d3.geo.transform({ point: projectPoint }),
                    path = d3.geo.path().projection(transform);

                var feature = g.selectAll("path")
                    .data(roomColumn.features)
                  .enter().append("path");

                var style = selectLegendItem(i);

                geoMap.on("viewreset", reset);

                reset();

                // Reposition the SVG to cover the features.
                function reset() {

                    var bounds = path.bounds(roomColumn),
                        topLeft = bounds[0],
                        bottomRight = bounds[1];

                    svg.attr("width", bottomRight[0] - topLeft[0])
                        .attr("height", bottomRight[1] - topLeft[1])
                        .style("left", topLeft[0] + "px")
                        .style("top", topLeft[1] + "px");

                    g.attr("transform", "translate(" + -topLeft[0] + "," + -topLeft[1] + ")");
                    feature.attr("d", path)
                        .style("fill", style.color);
                }

                // Use Leaflet to implement a D3 geometric transformation.
                function projectPoint(x, y) {
                    var point = geoMap.latLngToLayerPoint(new L.LatLng(y, x));
                    this.stream.point(point.x, point.y);
                }
            }


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