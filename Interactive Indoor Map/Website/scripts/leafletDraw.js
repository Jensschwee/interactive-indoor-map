﻿function leafletDraw(JSONMap) {
    var map = L.map('map').fitBounds([[55.36698307259987, 10.430810451507568]]),
	requestData = function (success, error) {
	    L.Realtime.reqwest({
	        url: JSONMap,
	        crossOrigin: true,
	        type: 'json'
	    }).then(function (data) {
	        success(data
	                //.filter(function (location) {
	                //    return location.lat > 0 || location.lon > 0;
	                //}
	            )
	            .map(function(location) {
	                return {
	                    type: 'Feature',
	                    properties: {
	                        id: location.id
	                        //fillColor: location.fill,
	                        //"stroke-width": 1
	                    },
	                    geometry: {
	                        type: 'Polygon',
	                        coordinates: [
	                            [location.constructor[0]],
	                            [location.constructor[1]],
	                            [location.constructor[2]],
	                            [location.constructor[3]],
	                            [location.constructor[4]]
	                        ]
	                    }
	                };
	            })
	        ;
	    }).catch(function (err) {
	        error(err);
	    });
	},

    realtime = L.realtime(requestData, {
        interval: 3 * 1000,
        style: style,
        onEachFeature: function (feature, layer) {
            layer.bindPopup(feature.properties.id);
        }
    }).addTo(map);

    L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
    }).addTo(map);
}

function style(feature) {
    return {
        fillColor: feature.properties.fill, //getPower(feature.properties.power),
        color: 'white',//feature.properties.stroke,
        weight: 1,
        opacity: 1,
        fillOpacity: 1
    };
}

function getPower(power) {
    return power > 1000 ? '#800026' :
           power > 500 ?  '#BD0026' :
           power > 200 ?  '#E31A1C' :
           power > 100 ?  '#FC4E2A' :
           power > 50 ?   '#FD8D3C' :
           power > 20 ?   '#FEB24C' :
           power > 10 ?   '#FED976' :
                          '#FFEDA0';
}
