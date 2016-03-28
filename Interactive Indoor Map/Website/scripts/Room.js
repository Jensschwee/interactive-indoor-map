function drawRooms(colletionOfRooms) {
    var rooms = null;
    if (colletionOfRooms != null) {
        rooms = JSON.parse(colletionOfRooms);
    } else {
        rooms = colletionOfRoomsOnMap;
    }
    var numberOfLayers = roomLayers.length;
    for (var k = 0; k < numberOfLayers; k++) {
        geoMap.removeLayer(roomLayers.pop());

    }

    //d3.select("body").selectAll("div.leaflet-overlay-pane").selectAll("svg.rooms").remove();
    var column = new Array();
    for (var j = 0; j < ActiveViews.length; j++) {
        var features = new Array();
        var jsonColumn = {
            type: "FeatureCollection",
            features: features
        };
        $.each(rooms.features, function (index, value) {
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
            if (ActiveViews[j].hasOwnProperty("min")) {
                minValue = value.properties[ActiveViews[j].min];
            }
            var maxValue = 1;
            if (ActiveViews[j].hasOwnProperty("max")) {
                maxValue = value.properties[ActiveViews[j].max];
            }

            var sensorValue = value.properties[ActiveViews[j].value];

            var point = [];
            //Col A X
            point.push(A[0] + ((D[0] - A[0]) / ActiveViews.length) * j);
            //Col A y
            point.push(A[1] + ((D[1] - A[1]) / ActiveViews.length) * j);


            coordinates.push(point);

            point = [];
            //Col D X
            point.push(A[0] + ((D[0] - A[0]) / ActiveViews.length) * (j + 1));

            //Col D y
            point.push(A[1] + ((D[1] - A[1]) / ActiveViews.length) * (j + 1));

            coordinates.push(point);
            point = [];
            //Col C X
            point.push(B[0] + ((C[0] - B[0]) / ActiveViews.length) * (j + 1) - ((B[0] - A[0]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

            //Col C y
            point.push(B[1] + ((C[1] - B[1]) / ActiveViews.length) * (j + 1) - ((B[1] - A[1]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

            coordinates.push(point);

            point = [];
            //Col B X
            point.push(B[0] + ((C[0] - B[0]) / ActiveViews.length) * (j) - ((B[0] - A[0]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

            //Col B y
            point.push(B[1] + ((C[1] - B[1]) / ActiveViews.length) * (j) - ((B[1] - A[1]) * (1 - (sensorValue - minValue) / (maxValue - minValue))));

            coordinates.push(point);

            coordinates.push(coordinates[0]);

            features.push(feature);

        });
        column.push(jsonColumn);
    }

    for (var i = 0; i < ActiveViews.length; i++) {
        var roomColumn = column.shift();

        roomLayers.push(L.geoJson(roomColumn, {
            style: {
                //Backgrund color
                fillColor: ActiveViews[i].color,
                //border color
                color: "none",
                //Border thickness
                opacity: "none",
                fillOpacity: "none"
            }
        }).addTo(geoMap).bringToBack());

        

        // var svg = d3.select(geoMap.getPanes().overlayPane).insert("svg").attr("class", "rooms"),
        //g = svg.append("g").attr("class", "leaflet-zoom-hide leaflet-zoom-animated");

        // var transform = d3.geo.transform({ point: projectPoint }),
        //     path = d3.geo.path().projection(transform);

        // var feature = g.selectAll("path")
        //     .data(roomColumn.features)
        //   .enter().append("path");


        // geoMap.on("viewreset", reset);

        // reset();

        // // Reposition the SVG to cover the features.
        // function reset() {

        //     var bounds = path.bounds(roomColumn),
        //         topLeft = bounds[0],
        //         bottomRight = bounds[1];

        //     svg.attr("width", bottomRight[0] - topLeft[0])
        //         .attr("height", bottomRight[1] - topLeft[1])
        //         .style("left", topLeft[0] + "px")
        //         .style("top", topLeft[1] + "px");

        //     g.attr("transform", "translate(" + -topLeft[0] + "," + -topLeft[1] + ")");
        //     feature.attr("d", path)
        //         .style("fill", ActiveViews[i].color);

        // }

        // // Use Leaflet to implement a D3 geometric transformation.
        // function projectPoint(x, y) {
        //     var point = geoMap.latLngToLayerPoint(new L.LatLng(y, x));
        //     this.stream.point(point.x, point.y);
        // }
        // drawRoomsBackgrund(colletionOfRoomsOnMap);

    }
}

function getRoomsAndDrawRooms() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsBackgrund(colletionOfRoomsOnMap);
        drawRooms();
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function drawRoomsBackgrund(json) {
    if (roomBackgroundLayer != null) {
        geoMap.removeLayer(roomBackgroundLayer);
    }
    roomBackgroundLayer = L.geoJson(json, {
        style: {
            //Backgrund color
            fillColor: "#FFFFFF",
            //border color
            color: "#FFFFFF",
            //Border thickness
            weight: 5,
            opacity: 10,
            fillOpacity: 0.2
        }
        ,
        onEachFeature: onEachFeature
    });
    roomBackgrundLayer.setZIndex(1).addTo(geoMap);
}

function onEachFeature(feature, layer) {
    layer.on({
        click: highlightFeature
    });
}

function resetSelectedRooms() {
    roomArray = [];
}