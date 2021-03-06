﻿$(document).ready(function () {
    GetPageData(1);
});
function GetPageData(pageNum, pageSize) {
    $("#tblData").empty();
    $("#paged").empty();
    $.getJSON("/Home/GetPaggedData", { pageNumber: pageNum, pageSize: pageSize }, function (response) {
        var rowData = "";
        for (var i = 0; i < response.data.length; i++) {
            rowData = rowData + '<tr><td>' + response.data[i].stamp + '</td><td>' + response.data[i].text + '</td></tr>';
        }
        $("#tblData").append(rowData);
        PaggingTemplate(response.totalPages, response.currentPage, response.pageSize);
    });
}
function PaggingTemplate(totalPage, currentPage, pageSize) {
    var template = "";
    var TotalPages = totalPage;
    var CurrentPage = currentPage;
    var PageNumberArray = Array();


    var countIncr = 1;
    for (var i = currentPage; i <= totalPage; i++) {
        PageNumberArray[0] = currentPage;
        if (totalPage != currentPage && PageNumberArray[countIncr - 1] != totalPage) {
            PageNumberArray[countIncr] = i + 1;
        }
        countIncr++;
    };
    PageNumberArray = PageNumberArray.slice(0, 5);
    var FirstPage = 1;
    var LastPage = totalPage;
    if (totalPage != currentPage) {
        var ForwardOne = currentPage + 1;
    }
    var BackwardOne = 1;
    if (currentPage > 1) {
        BackwardOne = currentPage - 1;
    }
    var picker = '';
    if (pageSize === 20) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20" selected>20</option><option value="50">50</option><option value="100">100</option><option value="150">150</option><option value="500">500</option><option value="5000">5000</option></select> </li>';
    } else if (pageSize === 50) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20">20</option><option value="50" selected>50</option><option value="100">100</option><option value="150">150</option><option value="500">500</option><option value="5000">5000</option></select> </li>';
    } else if (pageSize === 100) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20">20</option><option value="50">50</option><option value="100" selected>100</option><option value="150">150</option><option value="500">500</option><option value="5000">5000</option></select> </li>';
    } else if (pageSize === 150) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20">20</option><option value="50">50</option><option value="100">100</option><option value="150" selected>150</option><option value="500">500</option><option value="5000">5000</option></select> </li>';
    } else if (pageSize === 500) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20">20</option><option value="50">50</option><option value="100">100</option><option value="150">150</option><option value="500" selected>500</option><option value="5000">5000</option></select> </li>';
    } else if (pageSize === 5000) {
        picker = '<li><select ng-model="pageSize" id="selectedId"><option value="20">20</option><option value="50">50</option><option value="100">100</option><option value="150">150</option><option value="500">500</option><option value="5000" selected>5000</option></select> </li>';
    }


    template = "<p>" + CurrentPage + " of " + TotalPages + " pages</p>"
    template = template + '<ul class="pager">' +
        '<li class="previous"><a href="#" onclick="GetPageData(' + FirstPage + ',' + pageSize + ')"><i class="fa fa-fast-backward"></i>&nbsp;First</a></li>' +
        picker +
        '<li><a href="#" onclick="GetPageData(' + BackwardOne + ',' + pageSize + ')"><i class="glyphicon glyphicon-backward"></i></a>';

    var numberingLoop = "";
    for (var i = 0; i < PageNumberArray.length; i++) {
        numberingLoop = numberingLoop + '<a class="page-number active" onclick="GetPageData(' + PageNumberArray[i] + ',' + pageSize + ')" href="#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a>'
    }
    template = template + numberingLoop + '<a href="#" onclick="GetPageData(' + ForwardOne + ',' + pageSize + ')" ><i class="glyphicon glyphicon-forward"></i></a></li>' +
        '<li class="next"><a href="#" onclick="GetPageData(' + LastPage + ',' + pageSize + ')">Last&nbsp;<i class="fa fa-fast-forward"></i></a></li></ul>';
    $("#paged").append(template);
    $('#selectedId').change(function () {
        GetPageData(1, $(this).val());
    });
}