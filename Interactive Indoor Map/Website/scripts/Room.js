var xCoordinate = 0;
var yCoordinate = 1;

function splitRoomsIntoBarchart(colletionOfRooms) {
    colletionOfRooms = typeof colletionOfRooms !== 'undefined' ? colletionOfRooms : colletionOfRoomsOnMap;

    var numberOfLayers = roomLayers.length;
    for (var k = 0; k < numberOfLayers; k++) {
        geoMap.removeLayer(roomLayers.pop());
    }
    if (linesOnMap != null) {
        geoMap.removeLayer(linesOnMap);
    }
    if (averageTemporalLineOnMap != null) {
        geoMap.removeLayer(averageTemporalLineOnMap);
    }

    var column = new Array();
    var jsonColumn;
    var featuresLines = new Array();
    var jsonMinMaxLines = {
        type: "FeatureCollection",
        features: featuresLines
    };
    for (var columnNumber = 0; columnNumber < ActiveViews.length; columnNumber++) {
        var features = new Array();
        jsonColumn = {
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
            if (ActiveViews[columnNumber].hasOwnProperty("min")) {
                minValue = value.properties[ActiveViews[columnNumber].min];
            }
            var maxValue = 1;
            if (ActiveViews[columnNumber].hasOwnProperty("max")) {
                maxValue = value.properties[ActiveViews[columnNumber].max];
            }

            if (!temporalActive) {
                var sensorValue = 0;
                if (value.properties.hasOwnProperty(ActiveViews[columnNumber].value)) {
                    sensorValue = value.properties[ActiveViews[columnNumber].value];
                }
                DrawColnumLiveRoom(features,feature, coordinates, sensorValue, maxValue, minValue, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex);
            } else {
                DrawColnumTemporalRoom(features, feature, coordinates, value.properties[ActiveViews[columnNumber].minObserved], value.properties[ActiveViews[columnNumber].maxObserved], maxValue, minValue, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex);
                drawAverageObservedLines(featuresLines, columnNumber, value.properties[ActiveViews[columnNumber].average], minValue, maxValue, bottomRightVertex, bottomLeftVertex, topRightVertex, topLeftVertex);
            }

        });
        column.push(jsonColumn);
    }

    //LineString
    var features2 = new Array();
    var jsonLines = {
        type: "FeatureCollection",
        features: features2
    }

    if (column.length > 0) {
        $.each(colletionOfRooms.features, function (index, value) {

            //bottomRightVertex
            var bottomRightVertex = value.geometry.coordinates[0][2];

            //bottomLeftVertex
            var bottomLeftVertex = value.geometry.coordinates[0][1];

            ////topRightVertex
            var topRightVertex = value.geometry.coordinates[0][3];

            ////topLeftVertex
            var topLeftVertex = value.geometry.coordinates[0][0];


            for (var l = 1; l < 4; l++) {
                var coordinate2 = new Array();
                var coordinates2 = new Array();

                coordinate2.push(coordinates2);
                var geometry2 =
                {
                    type: "LineString",
                    coordinates: coordinates2
                };
                var feature2 = {
                    type: "Feature",
                    geometry: geometry2
                }
                var point = [];
                point.push(bottomLeftVertex[xCoordinate] + (topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * 0.25 * l);
                point.push(bottomLeftVertex[yCoordinate] + (topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * 0.25 * l);
                coordinates2.push(point);
                point = [];
                point.push(bottomRightVertex[xCoordinate] + (topRightVertex[xCoordinate] - bottomRightVertex[xCoordinate]) * 0.25 * l);
                point.push(bottomRightVertex[yCoordinate] + (topRightVertex[yCoordinate] - bottomRightVertex[yCoordinate]) * 0.25 * l);
                coordinates2.push(point);
                features2.push(feature2);
            }
        });
        linesOnMap = L.geoJson(jsonLines, {
            style: {
                color: "white", //border color
                opacity: "none",
                weight: "1px" //Border thickness
            }
        }).addTo(geoMap);
        if (temporalActive) {
            averageTemporalLineOnMap = L.geoJson(jsonMinMaxLines, {
                style: {
                    color: "black", //border color
                    opacity: "none",
                    weight: "2px" //Border thickness
                }
            }).addTo(geoMap).bringToFront();
            roomForegroundLayer.bringToFront();
        }
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
    if (roomBackgroundLayer != null)
        roomBackgroundLayer.bringToBack();
}

function getRoomsAndDrawRoomsWithRoomOverlays(jsonMap) {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsForeground(colletionOfRoomsOnMap);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    if (jsonMap !== 'undefined') {
        colletionOfRoomsOnMap = jsonMap;
        drawRoomsForeground(jsonMap);
        splitRoomsIntoBarchart(jsonMap);
    }
    else if (!temporalActive) {
        PageMethods.DrawFloor(currentFloorLevel, onSuccess);
    } else {
        getTemporalData();
    }

    getRoomsAndDrawBackground();
}

function drawAverageObservedLines(featuresLines, columnNumber, roomAverage, roomMin, roomMax, bottomRightVertex, bottomLeftVertex, topRightVertex, topLeftVertex) {
    //calc the hight for the min line
    var roomHeightAverage = (1 - (roomAverage - roomMin) / (roomMax - roomMin));
    if (roomHeightAverage < 0) {
        roomHeightAverage = 0;
    }
    else if (roomHeightAverage > 1) {
        roomHeightAverage = 1;
    }

    drawlines = function (value, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex) {
        var coordinates = new Array();

        var geometry =
            {
                type: "LineString",
                coordinates: coordinates
            };
        var feature = {
            type: "Feature",
            geometry: geometry
        }

        var point = [];
        point.push(topLeftVertex[xCoordinate] + ((topRightVertex[xCoordinate] - topLeftVertex[xCoordinate]) / ActiveViews.length) * (columnNumber) - ((topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * value));
        point.push(topLeftVertex[yCoordinate] + ((topRightVertex[yCoordinate] - topLeftVertex[yCoordinate]) / ActiveViews.length) * (columnNumber) - ((topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * value));
        coordinates.push(point);

        point = [];
        point.push(topLeftVertex[xCoordinate] + ((topRightVertex[xCoordinate] - topLeftVertex[xCoordinate]) / ActiveViews.length) * (columnNumber + 1) - ((topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * value));
        point.push(topLeftVertex[yCoordinate] + ((topRightVertex[yCoordinate] - topLeftVertex[yCoordinate]) / ActiveViews.length) * (columnNumber + 1) - ((topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * value));
        coordinates.push(point);

        featuresLines.push(feature);
    }
    drawlines(roomHeightAverage, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex);
}

function getRoomsAndDrawRooms() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function getRoomsAndDrawBackground() {
    function onSuccess(response) {
        var roomsBackground = JSON.parse(response);
        drawRoomsBackground(roomsBackground);
    }
    PageMethods.DrawRoomsBackground(currentFloorLevel, onSuccess);
}

function drawRoomsBackground(json) {
    if (roomBackgroundLayer != null) {
        geoMap.removeLayer(roomBackgroundLayer);
    }
    roomBackgroundLayer = L.geoJson(json, {
        style: backgroundStyle
    });
    var backLayer = 0;
    roomBackgroundLayer.setZIndex(backLayer).addTo(geoMap);
    roomBackgroundLayer.bringToBack();
}

function backgroundStyle(feature) {
    return {
        //Background color
        fillColor: getRoomBackgroundColor(feature.properties.RoomType),
        //border color
        color: getRoomBorderColor(feature.properties.RoomType),
        //Border thickness
        fillOpacity: 1.0
    };
}

function getRoomBackgroundColor(RoomType) {
    return RoomType === "Classroom" ? '#D0D6DC' :
           RoomType === "Studyzone" ? '#D0D6DC' :
           RoomType === "Office" ? '#C2B49D' :
           RoomType === "Hallway" ? '#C2B49D' :
           RoomType === "Stairs" ? '#C2B49D' :
           RoomType === "Elevator" ? '#C2B49D' :
           RoomType === "Toilet" ? '#C2B49D' :
           RoomType === "Utility" ? '#C2B49D' :
           '#FFFFFF';
}

function getRoomBorderColor(RoomType) {
    return RoomType === "Classroom" ? '#FFFFFF' :
           RoomType === "Studyzone" ? '#FFFFFF' :
           RoomType === "Office" ? '#C2B49D' :
           RoomType === "Hallway" ? '#C2B49D' :
           RoomType === "Stairs" ? '#C2B49D' :
           RoomType === "Elevator" ? '#C2B49D' :
           RoomType === "Toilet" ? '#C2B49D' :
           RoomType === "Utility" ? '#C2B49D' :
           '#FFFFFF';
}

function drawRoomsForeground(json) {

    if (roomForegroundLayer != null) {
        geoMap.removeLayer(roomForegroundLayer);
    }

    var roomOnClickEventHandler = function (feature, layer) {
        layer.on({
            click: onRoomClicked
        });
    };

    roomForegroundLayer = L.geoJson(json, {
        style: {
            //Background color
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
    roomForegroundLayer.setZIndex(frontLayer).addTo(geoMap);
}

function changeFloor() {
    roomArray = [];
    getRoomsAndDrawRoomsWithRoomOverlays();
}

function DrawColnumLiveRoom(features,feature, coordinates, sensorValue, maxValue, minValue, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex) {
    var roomColumnWidthX = ((bottomRightVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) / ActiveViews.length);
    var roomColumnWidthY = ((bottomRightVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) / ActiveViews.length);

    var roomBottomLeftColumnOffsetX = roomColumnWidthX * columnNumber;
    var roomBottomLeftColumnOffsetY = roomColumnWidthY * columnNumber;

    var point = [];
    //Column bottomLeftVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomBottomLeftColumnOffsetX);
    //Column bottomLeftVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomBottomLeftColumnOffsetY);

    coordinates.push(point);

    point = [];

    var roomBottomRightColumnOffsetX = roomColumnWidthX * (columnNumber + 1);
    var roomBottomRightColumnOffsetY = roomColumnWidthY * (columnNumber + 1);
    //Column bottomRightVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomBottomRightColumnOffsetX);

    //Column bottomRightVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomBottomRightColumnOffsetY);

    coordinates.push(point);

    //calc the hight of the room
    var roomHeight = ((sensorValue - minValue) / (maxValue - minValue));

    //If the room is to fill more then 100%
    if (roomHeight < 0) {
        roomHeight = 0;
    }
        //If the room is to fill less then 0%
    else if (roomHeight > 1) {
        roomHeight = 1;
    }

    var roomHeightX = ((topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * roomHeight);
    var roomHeightY = ((topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * roomHeight);

    var roomTopRightColumnOffsetX = roomColumnWidthX * (columnNumber + 1);
    var roomTopRightColumnOffsetY = roomColumnWidthY * (columnNumber + 1);

    point = [];
    //Column TopRightVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomTopRightColumnOffsetX + roomHeightX);
    //Column TopRightVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomTopRightColumnOffsetY + roomHeightY);
    coordinates.push(point);

    point = [];
    var roomTopLeftColumnOffsetX = roomColumnWidthX * columnNumber;
    var roomTopLeftColumnOffsetY = roomColumnWidthY * columnNumber;

    //Column TopLeftVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomTopLeftColumnOffsetX + roomHeightX);
    //Column TopLeftVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomTopLeftColumnOffsetY + roomHeightY);

    coordinates.push(point);

    coordinates.push(coordinates[0]);

    features.push(feature);
}

function DrawColnumTemporalRoom(features, feature, coordinates, minObserved, maxObserved, maxValue, minValue, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex) {
    var roomColumnWidthX = ((bottomRightVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) / ActiveViews.length);
    var roomColumnWidthY = ((bottomRightVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) / ActiveViews.length);

    var roomBottomLeftColumnOffsetX = roomColumnWidthX * columnNumber;
    var roomBottomLeftColumnOffsetY = roomColumnWidthY * columnNumber;


    var roomMinHeight = ((minObserved - minValue) / (maxValue - minValue));

    //If the room is to fill more then 100%
    if (roomMinHeight < 0) {
        roomMinHeight = 0;
    }
        //If the room is to fill less then 0%
    else if (roomMinHeight > 1) {
        roomMinHeight = 1;
    }

    var roomMinHeightX = ((topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * roomMinHeight);
    var roomMinHeightY = ((topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * roomMinHeight);

    var point = [];
    //Column bottomLeftVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomBottomLeftColumnOffsetX + roomMinHeightX);
    //Column bottomLeftVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomBottomLeftColumnOffsetY + roomMinHeightY);

    coordinates.push(point);

    point = [];

    var roomBottomRightColumnOffsetX = roomColumnWidthX * (columnNumber + 1) + roomMinHeightX;
    var roomBottomRightColumnOffsetY = roomColumnWidthY * (columnNumber + 1) + roomMinHeightY;
    //Column bottomRightVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomBottomRightColumnOffsetX);

    //Column bottomRightVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomBottomRightColumnOffsetY);

    coordinates.push(point);

    //calc the hight of the room
    var roomMaxHeight = ((maxObserved - minValue) / (maxValue - minValue));

    //If the room is to fill more then 100%
    if (roomMaxHeight < 0) {
        roomMaxHeight = 0;
    }
        //If the room is to fill less then 0%
    else if (roomMaxHeight > 1) {
        roomMaxHeight = 1;
    }

    var roomMaxHeightX = ((topLeftVertex[xCoordinate] - bottomLeftVertex[xCoordinate]) * roomMaxHeight);
    var roomMaxHeightY = ((topLeftVertex[yCoordinate] - bottomLeftVertex[yCoordinate]) * roomMaxHeight);

    var roomTopRightColumnOffsetX = roomColumnWidthX * (columnNumber + 1);
    var roomTopRightColumnOffsetY = roomColumnWidthY * (columnNumber + 1);

    point = [];
    //Column TopRightVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomTopRightColumnOffsetX + roomMaxHeightX);
    //Column TopRightVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomTopRightColumnOffsetY + roomMaxHeightY);
    coordinates.push(point);

    point = [];
    var roomTopLeftColumnOffsetX = roomColumnWidthX * columnNumber;
    var roomTopLeftColumnOffsetY = roomColumnWidthY * columnNumber;

    //Column TopLeftVertex X
    point.push(bottomLeftVertex[xCoordinate] + roomTopLeftColumnOffsetX + roomMaxHeightX);
    //Column TopLeftVertex Y
    point.push(bottomLeftVertex[yCoordinate] + roomTopLeftColumnOffsetY + roomMaxHeightY);

    coordinates.push(point);

    coordinates.push(coordinates[0]);

    features.push(feature);
}