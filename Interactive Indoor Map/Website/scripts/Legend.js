var legendArray = new Array();

function drawLegend() {
    var activeViews = ActiveViews.length;
    d3.select("#legend").selectAll("svg").remove();
    d3.select("#legend").selectAll("div").remove();
    if (activeViews != 0) {
        var imageStartPos = 43;
        if (activeViews === 2) {
            imageStartPos = 15;
        }
        else if (activeViews === 3) {
            imageStartPos = 7;
        }
        else if (activeViews === 4) {
            imageStartPos = 4;
        }

        ActiveViews.forEach(function (view, i) {
            d3.select("#legend")
             .append("svg")
              .attr("width", 100 / activeViews + '%')
              .attr("height", '100%')
              .append("rect")
              .attr("width", 100 + '%')
              .attr('stroke-width', 1)
              .attr('stroke', 'rgb(0,0,0)')
              .attr("height", 100 + '%')
              .style("fill", ActiveViews[i].color)
                .on('click', function () {
                    onLegendItemClicked(i);
                });


            d3.select("#legend")
                .append('div')
                .attr("class", 'IconImage')
                .attr("style", 'top: 42%; left:' + (100 / activeViews * i + imageStartPos) + '%')
                .append('img')
                .attr("width", 25)
                .attr("height", 25)
                .attr("src", ActiveViews[i].icon);

        });
    }
}

function onLegendItemClicked(number) {
    ActiveViews.splice(number, 1);
    drawLegend();
    drawRooms();
}