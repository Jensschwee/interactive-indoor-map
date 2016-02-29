/**
 * This function is used for creating and updating the legend on the map
 * @param {} grade collections of items to use in the legend
 * @param {} coloring the collering for the items, this must be a function
 * @param {} siUnit the unit for all the items
 */
function drawLegend(grade, coloring, siUnit) {

    //Removes the old legend
    if (legend != null) {
        geoMap.removeControl(legend);
    }

    legend = L.control({ position: 'bottomright' });

    //addeds the 
    legend.onAdd = function (map) {
        //Creates the div for the legend
        var div = L.DomUtil.create('div', 'info legend'),
            grades = grade;
            //labels = [];

        // loop through our density intervals and generate a label with a colored square for each interval
        for (var i = 0; i < grades.length; i++) {
            div.innerHTML +=
                '<i style="background:' + coloring(grades[i]) + '"></i> ' +
                grades[i] + (grades[i + 1] ? siUnit + '<br>' : siUnit);
        }
        return div;
    };

    //addes the legend to the map
    legend.addTo(geoMap);
}