document.addEventListener("DOMContentLoaded", function (event) {

    document.getElementById("nursinghomes").addEventListener("click", function () {
        GetShowDataQuery2();
        GetShowDataQuery3();
    });

});
function GetShowDataQuery2() {
    $.getJSON("api/final/query2")
        .done(function (data) {
            let table = document.getElementById("table2");
            console.log(data);
            generateTable(table, data);
        });
}
function GetShowDataQuery3() {
    $.getJSON("api/final/query3")
        .done(function (data) {
            let table = document.getElementById("table3");
            console.log(data);
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
//function GetShowDataQuery3() {
//    $.getJSON("api/final/query3")
//        .done(function (data) {
//            let table = document.getElementById("table3");
//            console.log(data);
//            $.each(data, function (key, item) {
//                console.log(data);
//                for (let element of data) {
//                    let row = table.insertRow();
//                    for (key in element) {
//                        let cell = row.insertCell();
//                        let text = document.createTextNode(item);

//                        cell.appendChild(text);
//                    }
//                }
//            });
//        });
//}
//function GetShowDataQuery3() {
//    $.getJSON("api/final/query3")
//        .done(function (data) {
//            //document.getElementById("displayRace2").innerHTML = data[0] + "   " + data[1] + "   " + data[2] + "   " + data[3];
//            let table = document.getElementById("table3");
//            console.log(data);
//            let row = table.insertRow();
//            $.each(data, function (key, item) {
//                console.log(data);
//                let cell = row.insertCell();
//                let text = document.createTextNode(item);
//                cell.appendChild(text);
//            });


//        });
//}

