function DrawLegend(grade, collerting, unit) {
    if (legend != null) {
        geoMap.removeControl(legend);
    }

    legend = L.control({ position: 'bottomright' });

    legend.onAdd = function (map) {

        var div = L.DomUtil.create('div', 'info legend'),
            grades = grade,
            labels = [];

        // loop through our density intervals and generate a label with a colored square for each interval
        for (var i = 0; i < grades.length; i++) {
            div.innerHTML +=
                '<i style="background:' + collerting(grades[i]) + '"></i> ' +
                //(grades[i + 1] ? '' : '-') +
                //(grades[i - 1] ? '' : '+') +
                grades[i] + (grades[i + 1] ? unit + '<br>' : unit);
            //'<i style="background:' + getColor(grades[i] + 1) + '"></i> ' +
            //grades[i] + (grades[i + 1] ? '&ndash;' + grades[i + 1] + '<br>' : '+');
        }
        return div;
    };

    legend.addTo(geoMap);
}