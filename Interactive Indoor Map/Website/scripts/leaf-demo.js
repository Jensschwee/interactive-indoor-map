// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

function style(feature) {
    return {
        fillColor: feature.properties.fill,
        weight: 2,
        opacity: 1,
        color: 'white',
        dashArray: '3',
        fillOpacity: 0.7
    };
}

function leafletDraw(JSONMap) {
    var worldMap = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
        center: [55.36698307259987, 10.430810451507568],
        minZoom: 2,
        zoom: 18
    });

    //$.getJSON("map/map.json", function (data) {
    //    var geojson = L.geoJson(data, {
    //        onEachFeature: function (feature, layer) {
    //            layer.bindPopup(feature.properties.name);
    //            layer.setStyle({
    //                fillColor: feature.properties.fill,
    //                weight: 1,
    //                fillOpacity: 0.8
    //            });
    //        }
    //    });
    //});
    //var json;

    //var geojson = L.geoJson().addData(JSONMap);

    //var map = L.map('map'),
    //realtime = L.realtime({
    //    url: 'map/map.JSON',
    //    crossOrigin: false,
    //    type: 'json'
    //}, {
    //    interval: 3 * 1000
    //}).addTo(map);

    //var map = L.map('map'),
    // realtime = L.realtime({
    //     url: JSONMap,
    //     crossOrigin: true,
    //     type: 'json'
    // },
    // {
    //     interval: 3 * 1000
    //     //, updateFeature: function (feature, oldLayer, newLayer) {
    //     ////    //newLayer.setStyle({});
    //     //}
    // }).addTo(map);

    //realtime.on('update', function (e) {
    //    //console.log(e);
    //    map.fitBounds(realtime.getBounds(), { maxZoom: 18 });
    //});

    var featureLayer = L.mapbox.featureLayer()
    .loadURL(JSONMap)
    // Once this layer loads, we set a timer to load it again in a few seconds.
    .on('ready', run)
    .addTo(map);

    function run() {
        featureLayer.eachLayer(function (l) {
            map.panTo(l.getLatLng());
        });
        window.setTimeout(function () {
            featureLayer.loadURL(JSONMap);
        }, 2000);
    }

    worldMap.addTo(map);

    //var GeoMap = L.map('map').fitBounds(geojson.getBounds());
    //worldMap.addTo(map);
    //geojson.addTo(GeoMap);
    //json.addTo(GeoMap);
}

