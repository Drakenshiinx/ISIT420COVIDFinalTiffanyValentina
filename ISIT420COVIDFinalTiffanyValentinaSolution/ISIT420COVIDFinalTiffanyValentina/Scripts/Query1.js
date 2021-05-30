function GetShowDataQuery1() {

    $.getJSON("api/covid/query1")
        .done(function (data) {
            //$.each(data, function (key, item) {
               // Add a list item for the product.
                //$('<li>', { text: formatItem1(item) }).appendTo($('#displayRace1'));
            //});
            //console.log(data);
            let table = document.getElementById("table1");
            generateTable(table, data);
        });
}

function generateTable(table, data) {
    for (let element of data) {
        let row = table.insertRow();
        for (key in element) {
            let cell = row.insertCell();
            let text = document.createTextNode(element[key]);
            cell.appendChild(text);
        }
    }
}