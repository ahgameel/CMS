


function filterProducts2()
{
    return { Id: $("#CityIdQuick").val() };
}

function filterArea()
{
    return { Id: $("#CityId3").val() };
}

function filterAreas()
{
    //id: $("#City").val();
    return {
        Id: $("#City").val()
    };
}
function filterCustomerAreas()
{
    return { Id: $("#CityIdQuickC").val() };
}

//function filterProducts2()
//{
//    return { Id: $("#CityId2").val() };
//}
function filterOrderQuickArea()
{
    return { Id: $("#CityIdQ").val() };
}
function select(e)
{

    var dropdownlist = $("#City").data("kendoDropDownList");
    dropdownlist.value();
    var multiselect = $("#ServiceProviderAreas2").data("kendoMultiSelect");
    multiselect.dataSource.read();
};
function change()
{
    var multiselect = $("#ServiceProviderAreas2").data("kendoMultiSelect");
    multiselect.dataSource.read();
};
function onAdditionalDataQuick()
{
    return {
        term: $("#CustomerName2").val()
    };
}
function onSelectQuick(e)
{


    var dataItem = this.dataItem(e.item.index());
    if (dataItem != null)
    {
        $.ajax({
            type: 'GET',
            url: '../Order/GetCustomer',
            data: { name: dataItem.FullName },

            success: function (data)
            {

                $("#mobileQ").text(data.Mobile);
                $("#telephoneQ").text(data.Telephone);
                $("#addressQ").text(data.Address);
                $("#cityQ").text(data.CityName);
                $("#areaQ").text(data.AreaName);
                $("#areaidQ").val(data.AreaId);
                $("#CustomerIdQ").val(data.Id);
            },
            error: function (req, status, error)
            {
                alert("R: " + req + " S: " + status + " E: " + error);
            }
        });
    } else
    {
        $("#mobile").text("");
        $("#telephone").text("");
        $("#address").text("");
    }


}



//var getServiceCategoryNameQuickCreate = function(e) {
//    var array =' @Html.Raw(Json.Encode(ViewBag.servicecategories))';
//    for (var i = 0; i < array.length; i++) {
//        if ([array[i].Id] == e.ServiceCategoryId) {
//            return array[i].Name;
//        }
//    }
//};

function onSelectCallQuickCreate(e) {
    $("#OrdersBoxQuickCreate").show();
    var dataItem = this.dataItem(e.item.index());
    $(RelatedToId).val(dataItem.Id);
    $(RelatedTo).val("Customer");
    if (dataItem != null) {
        $.ajax({
            type: 'GET',
            url: '../../Calls/GetCustomerOrders',
            data: { custId: dataItem.Id },
            success: function(data) {
                debugger;
                var grid = $("#gridQuickCreate").kendoGrid({
                    dataSource: new kendo.data.DataSource({
                        data: data,
                        pageSize: 5
                    }),
                    groupable: true,
                    sortable: true,
                    selectable: true,
                    reorderable: true,
                    pageable: { input: true, numeric: false },
                    filterable: true,
                    filter: { logic: "and", filters: [] },
                    change: function() {
                        var text = "";
                        var grid = this;
                        grid.select().each(function() {
                            var dataItem = grid.dataItem($(this));
                            text += "OrderID: " + dataItem.Id + "\n";
                            $(RelatedToId).val(dataItem.Id);
                            $(RelatedTo).val("Order");
                        });
                    },
                    columns: [{
                        hidden: true,
                        field: "Id",
                        title: "Id",
                        width: 30,
                    }, {
                        field: "ServiceCategoryId",
                        title: "Service Category",
                        template: getServiceCategoryNameQuickCreate,
                        width: 30,
                    },
                        {
                            field: "CheckingDate",
                            title: "Checking Date",
                            template: "#= kendo.toString(kendo.parseDate(CheckingDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        }, {
                            field: "StartDate",
                            title: "Start Date",
                            template: "#= kendo.toString(kendo.parseDate(StartDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        }, {
                            field: "EndDate",
                            title: "End Date",
                            template: "#= kendo.toString(kendo.parseDate(EndDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        }]
                }).data("kendoGrid");
            },
            error: function(req, status, error) {
                alert("R: " + req + " S: " + status + " E: " + error);
            }
        });
    } else {

    }
}






//function onSelectCallQuickCreate(e)
//{
//    $("#OrdersBoxQuickCreate").show();
//    var dataItem = this.dataItem(e.item.index());
//    $(RelatedToId).val(dataItem.Id);
//    $(RelatedTo).val("Customer");
//    if (dataItem != null)
//    {
//        $.ajax({
//            type: 'GET',
//            url: '../../Calls/GetCustomerOrders',
//            data: { custId: dataItem.Id },
//            success: function (data)
//            {

//                $.servicecategoryDropDownEditor = function (container, options)
//                {
//                    $('<input required data-text-field="Name" data-value-field="Id" data-bind="value:' + options.field + '"/>')
//                        .appendTo(container)
//                        .kendoDropDownList({
//                            autoBind: false,
//                            dataSource: {
//                                type: "json",
//                                transport: {
//                                    read: {
//                                        url: "../../Calls/GetServiceCategory",
//                                        type: "POST"
//                                    }
//                                }
//                            }
//                        });
//                };

//                    var grid = $("#gridQuickCreate").kendoGrid({
//                        dataSource: new kendo.data.DataSource({
//                            data: data,
//                            pageSize: 5
//                        }),
                        
//                        groupable: true,
//                        sortable: true,
//                        selectable: true,
//                        reorderable: true,
//                        pageable: { input: true, numeric: false },
//                        filterable: true,
//                        filter: { logic: "and", filters: [] },
//                        change: function() {
//                            var text = "";
//                            var grid = this;
//                            grid.select().each(function() {
//                                var dataItem = grid.dataItem($(this));
//                                text += "OrderID: " + dataItem.Id + "\n";
//                                $(RelatedToId).val(dataItem.Id);
//                                $(RelatedTo).val("Order");
//                            });
//                        },
//                        columns: [{
//                            hidden: true,
//                            field: "Id",
//                            title: "Id",
//                            width: 30,
//                        }, {
//                            field: "ServiceCategoryId",
//                            title: "Service Category",
//                            editor: $.servicecategoryDropDownEditor, template: "#=Name#",
//                            width: 30,
//                        },
//                            {
//                                field: "CheckingDate",
//                                title: "Checking Date",
//                                template: "#= kendo.toString(kendo.parseDate(CheckingDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
//                                width: 30,
//                            }, {
//                                field: "StartDate",
//                                title: "Start Date",
//                                template: "#= kendo.toString(kendo.parseDate(StartDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
//                                width: 30,
//                            }, {
//                                field: "EndDate",
//                                title: "End Date",
//                                template: "#= kendo.toString(kendo.parseDate(EndDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
//                                width: 30,
//                            }]
//                    }).data("kendoGrid");


                   

//            },
//            error: function (req, status, error)
//            {
//                alert("R: " + req + " S: " + status + " E: " + error);
//            }
//        });
//    } else
//    {

//    }
//}

function onAdditionalDataQuickCreate()
{
    return {
        term: $("#CustomerNameQuickCreate").val()
    };
}
function onSelectServiceOfferQ(e) {

    var dataItem = this.dataItem(e.item);
    //kendoConsole.log("event :: select (" + dataItem.Text + " : " + dataItem.Value + ")");
    if (dataItem != null) {
        $.ajax({
            type: 'GET',
            url: '../../Order/GetServiceOfferPrice',
            data: { id: dataItem.Id },

            success: function (data) {


                $("#offerDetailsQ").text(dataItem.Summary);


            }
        });
    }

}


////////////////////////////////////////////////Orders Calender////////////////////////////////////////////////////////////////
function onAdditionalDataQuickCalender() {
    return {
        term: $("#CustomerNameCalender").val()
    };
}

function onSelectQuickCalender(e) {

    var dataItem = this.dataItem(e.item.index());
    if (dataItem != null) {
        $.ajax({
            type: 'GET',
            url: '../OrdersCalender/GetCustomerCalender',
            data: { name: dataItem.FullName },

            success: function (data) {

                $("#mobileCalender").text(data.Mobile);
                $("#telephoneCalender").text(data.Telephone);
                $("#addressCalender").text(data.Address);
                $("#cityCalender").text(data.CityName);
                $("#areaCalender").text(data.AreaName);
                $("#areaidcalender").val(data.AreaId);
                $("#CustomerIdCalender").val(data.Id);
            },
            error: function (req, status, error) {
                alert("R: " + req + " S: " + status + " E: " + error);
            }
        });
    } else {
        //$("#mobile").text("");
        //$("#telephone").text("");
        //$("#address").text("");
    }



}


function filterServiceOffersCalender() {
    return { Id: $("#ServiceCategoryIdCalender").val() };
}

function filterOrderQuickAreaCalender() {
    return { Id: $("#CityIdCalender").val() };
}

function filterCustomerAreasCalender() {
    return { Id: $("#CityIdQuickCalender").val() };
}



function AdditionalData_Calender() {

    //var areadropdown = $("#AreaId3").text();
    debugger;
    var index = $('#AreaIdCalender').data('kendoDropDownList').select();
    return {
        term: $("#SpName").val(),
        serviceCategoryId: $("#ServiceCategoryIdCalender").val(),

        areaId: function () {
            if (index != 0) {
                return $("#AreaIdCalender").val();
            } else {
                return $("#areaidcalender").val();
            }
        }
    };

}

function onSelectSp_Calender(e) {
    var mobile, address, area;
    if ($('#address_Calender').val() != "") {
        address = $('#address_Calender').val();
    }
    else { address = $('#address').text(); }

    if ($('#mobile_Calender').val() != "") {
        mobile = $('#mobile_Calender').val();
    } else {
        mobile = $('#mobileCalender').text();
    }
    if ($('#AreaIdCalender').val() != "") {
        area = $('#AreaIdCalender').data('kendoDropDownList').text();
    } else {
        area = $("#areaCalender").text();
    }
    debugger;
    var dataItem = this.dataItem(e.item.index());

    if (dataItem != null) {
        $("#ServiceProviderIdCalender").val(dataItem.Id);
    }
}

function onSelectServiceOfferCalender(e) {
    var dataItem = this.dataItem(e.item);
    //kendoConsole.log("event :: select (" + dataItem.Text + " : " + dataItem.Value + ")");
    if (dataItem != null) {
        $.ajax({
            type: 'GET',
            url: '../../OrdersCalender/GetServiceOfferPrice',
            data: { id: dataItem.Id },

            success: function (data) {
                $("#offerDetailsCalender").text(dataItem.Summary);
            }
        });
    }

}





function AdditionalDataFavourite() {
    return {
        term: $("#SpNameFavourite").val()
    };
}


function onSelectPunishmentQuickCreatePunishment(e) {
    $("#Orders_PunishmentBoxQuickCreate").show();
    var dataItem = this.dataItem(e.item.index());
    $(PunishmentReasonId).val(dataItem.Id);
    $(PunishmentReasonName).val("Order");
    debugger;
    if (dataItem != null) {
        $.ajax({
            type: 'GET',
            url: '../../Punishment/GetCustomerOrders',
            data: { custId: dataItem.Id },
            success: function (data) {
                debugger;
                var grid = $("#gridQuickCreatePunishment").kendoGrid({
                    dataSource: new kendo.data.DataSource({
                        data: data,
                        pageSize: 5
                    }),
                    groupable: true,
                    sortable: true,
                    selectable: true,
                    reorderable: true,
                    pageable: { input: true, numeric: false },
                    filterable: true,
                    filter: { logic: "and", filters: [] },
                    change: function () {
                        var text = "";
                        var grid = this;
                        grid.select().each(function () {
                            var dataItem = grid.dataItem($(this));
                            text += "OrderID: " + dataItem.Id + "\n";
                            $(PunishmentReasonId).val(dataItem.Id);
                            $(PunishmentReasonName).val("Order");
                        });
                    },
                    columns: [{
                        hidden: true,
                        field: "Id",
                        title: "Id",
                        width: 30,
                    },

                        {
                            field: "CheckingDate",
                            title: "Checking Date",
                            template: "#= kendo.toString(kendo.parseDate(CheckingDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        },

                           {
                               field: "ServiceCategoryId",
                               title: "Service Category",
                               template: getServiceCategoryNameQuick,
                               width: 30,
                           },

                        {
                            field: "StartDate",
                            title: "Start Date",
                            template: "#= kendo.toString(kendo.parseDate(StartDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        }, {
                            field: "EndDate",
                            title: "End Date",
                            template: "#= kendo.toString(kendo.parseDate(EndDate, 'yyyy-MM-dd'), 'dd/MM/yyyy') #",
                            width: 30,
                        }]
                }).data("kendoGrid");
            },
            error: function (req, status, error) {
                alert("R: " + req + " S: " + status + " E: " + error);
            }
        });
    } else {

    }
}



function onAdditionalDataQuickCreatePunishment() {
    return {
        term: $("#CustomerNamePunishmentQuickCreate").val()
    };
}


