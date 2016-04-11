function splitRoomsIntoBarchart(colletionOfRooms) {
    colletionOfRooms = typeof colletionOfRooms !== 'undefined' ? colletionOfRooms : colletionOfRoomsOnMap;

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
        $.each(colletionOfRooms.features, function (index, value) {
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
            var bottomRightVertex = value.geometry.coordinates[0][2];

            //bottomLeftVertex
            var bottomLeftVertex = value.geometry.coordinates[0][1];

            ////topRightVertex
            var topRightVertex = value.geometry.coordinates[0][3];

            ////topLeftVertex
            var topLeftVertex = value.geometry.coordinates[0][0];

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
            point.push(bottomLeftVertex[0] + ((bottomRightVertex[0] - bottomLeftVertex[0]) / ActiveViews.length) * j);
            //Col A y
            point.push(bottomLeftVertex[1] + ((bottomRightVertex[1] - bottomLeftVertex[1]) / ActiveViews.length) * j);


            coordinates.push(point);

            point = [];
            //Col D X
            point.push(bottomLeftVertex[0] + ((bottomRightVertex[0] - bottomLeftVertex[0]) / ActiveViews.length) * (j + 1));

            //Col D y
            point.push(bottomLeftVertex[1] + ((bottomRightVertex[1] - bottomLeftVertex[1]) / ActiveViews.length) * (j + 1));

            coordinates.push(point);

            //calc the hight of the room
            var roomHeight = (1 - (sensorValue - minValue) / (maxValue - minValue));

            //If the room is to fill more then 100%
            if (roomHeight < 0) {
                roomHeight = 0;
            }
            //If the room is to fill less then 0%
            else if (roomHeight > 1) {
                roomHeight = 1;
            }

            point = [];
            //Col C X
            point.push(topLeftVertex[0] + ((topRightVertex[0] - topLeftVertex[0]) / ActiveViews.length) * (j + 1) - ((topLeftVertex[0] - bottomLeftVertex[0]) * roomHeight));

            //Col C y
            point.push(topLeftVertex[1] + ((topRightVertex[1] - topLeftVertex[1]) / ActiveViews.length) * (j + 1) - ((topLeftVertex[1] - bottomLeftVertex[1]) * roomHeight));

            coordinates.push(point);

            point = [];
            //Col B X
            point.push(topLeftVertex[0] + ((topRightVertex[0] - topLeftVertex[0]) / ActiveViews.length) * (j) - ((topLeftVertex[0] - bottomLeftVertex[0]) * roomHeight));

            //Col B y
            point.push(topLeftVertex[1] + ((topRightVertex[1] - topLeftVertex[1]) / ActiveViews.length) * (j) - ((topLeftVertex[1] - bottomLeftVertex[1]) * roomHeight));

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
                color: "black",
                //Border thickness
                opacity: "none",
                fillOpacity: "none",
                weight: "1px"
            }
        }).addTo(geoMap).bringToBack());
    }
}

function getRoomsAndDrawRoomsWithRoomOverlay() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsBackground(colletionOfRoomsOnMap);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function getRoomsAndDrawRooms() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function drawRoomsBackground(json) {
    
    if (roomBackgroundLayer != null) {
        geoMap.removeLayer(roomBackgroundLayer);
    }

    var roomOnClickEventHandler = function (feature, layer) {
        layer.on({
            click: onRoomClicked
        });
    };

    roomBackgroundLayer = L.geoJson(json, {
        style: {
            //Backgrund color
            fillColor: "#FFFFFF",
            //border color
            color: "#FFFFFF",
            //Border thickness
            weight: 3,
            opacity: 10,
            fillOpacity: 0.0
        },
        onEachFeature: roomOnClickEventHandler
    });
    var frontLayer = 1;
    roomBackgroundLayer.setZIndex(frontLayer).addTo(geoMap);
}

function changeFloor() {
    roomArray = [];
    getRoomsAndDrawRoomsWithRoomOverlay();
}

function onRoomClicked(e) {
    var layer = e.target;

    if ($.inArray(layer.feature.properties.Name, roomArray) === -1) {
        //Select room
        layer.setStyle({
            //border color
            color: '#8c8c8c'
        }); 

        if (!L.Browser.ie && !L.Browser.opera) {
            layer.bringToFront();
        }

        roomArray.push(layer.feature.properties.Name);
    } else {
        roomArray = jQuery.grep(roomArray, function (value) {
            return value != layer.feature.properties.Name;
        });

        //Deselect room
        roomBackgroundLayer.resetStyle(e.target);
        infoBox.update();
    }

    buildingButton.button.style.backgroundColor = 'white';
    drawRoomInfo();
    infoboxUpdate = function () { drawSelectedRoomInfoBox(); };
    infoboxUpdate();
}