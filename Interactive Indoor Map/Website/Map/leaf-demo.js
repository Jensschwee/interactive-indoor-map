// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

var map = L.map( 'map', {
    center: [55.36698307259987, 10.430810451507568],
    minZoom: 2,
    zoom: 18
});

L.tileLayer( 'http://{s}.mqcdn.com/tiles/1.0.0/map/{z}/{x}/{y}.png', {
    subdomains: ['otile1','otile2','otile3','otile4']
}).addTo( map );

var myURL = jQuery( 'script[src$="leaf-demo.js"]' ).attr( 'src' ).replace( 'leaf-demo.js', '' );

//L.geoJson("map.json").addTo(map);

//var myIcon = L.icon({
//    iconUrl: myURL + 'images/pin24.png',
//    iconRetinaUrl: myURL + 'images/pin48.png',
//    iconSize: [29, 24],
//    iconAnchor: [9, 21],
//    popupAnchor: [0, -14]
//});

//for ( var i=0; i < markers.length; ++i ) 
//{
//   L.marker( [markers[i].lat, markers[i].lng], {icon: myIcon} )
//      .bindPopup( '<a href="' + markers[i].url + '" target="_blank">' + markers[i].name + '</a>' )
//      .addTo( map );
//}