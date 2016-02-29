var currentFloorLevel = 0;

function CreateButtons(CallBackDraw, style) {
    L.control.fullscreen({
        position: 'bottomleft'
    }).addTo(geoMap);
    //https://github.com/brunob/leaflet.fullscreen


    L.easyButton('-1;', function () {
        currentFloorLevel = -1;

        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(-1, onSuccess);
        function onSuccess(response, userContext, methodName) {
            CallBackDraw(response, style);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('0;', function () {
        currentFloorLevel = 0;

        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(0, onSuccess);
        function onSuccess(response, userContext, methodName) {
            CallBackDraw(response, style);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('1;', function () {
        currentFloorLevel = 1;

        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(1, onSuccess);
        function onSuccess(response, userContext, methodName) {
            CallBackDraw(response, style);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('2;', function () {
        currentFloorLevel = 2;

        if (geoMap != null) {
            geoMap.removeLayer(geojson);
        }

        PageMethods.DrawFloor(2, onSuccess);
        function onSuccess(response, userContext, methodName) {
            CallBackDraw(response, style);
        }
    }, { position: 'bottomleft' }).addTo(geoMap);
}