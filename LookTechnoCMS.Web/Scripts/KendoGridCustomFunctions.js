var wnd;
$(document).ready(function ()
{
    wnd = $("#modalWindow").kendoWindow({
        title: "Delete confirmation",
        modal: true,
        visible: false,
        resizable: false,
        width: 350
    }).data("kendoWindow");
    

});



function deleteGridRecord(e)
{
    e.preventDefault();

    var grid = this;
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
  
 
    wnd.center().open();

    $("#yes").click(function ()
    {
        //url: '/ServiceProvider/Delete?id=' + dataItem.id,
     
        $.ajax({
            type: "Post",
            url: Variables.DeleteUrl + "?id=" + dataItem.id,
            data: { id: dataItem.id },
            success: function (data)
            {

                if (data.ok == true)
                {

                    grid.removeRow($(e.currentTarget).closest("tr"));
               
                    wnd.close();
                    location.reload();
                    data.Message.show();

                } else
                {
                    
          
                }
            }

        });


    });

    $("#no").click(function ()
    {
        wnd.close();
    });

}




