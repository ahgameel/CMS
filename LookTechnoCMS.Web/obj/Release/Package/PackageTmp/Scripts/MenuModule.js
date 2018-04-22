

    $(document).ready(function () {
        $.get("/MenuModules/GetAllMenu", function (data) {
            var menuArr = [];
            var subMenuArr = [];
            var subMenuArr2 = [];
            for (var i = 0; i < data.length; i++) {
                if (data[i].ParentId == 0) {
                    menuArr.push(data[i]);
                }
                else {
                    subMenuArr.push(data[i]);
                }
            }
            var htmlContent = "";
            htmlContent += '<ul class="nav navbar-nav">';
            htmlContent += '<li class="active">';
            htmlContent += '<a href="index.html">';
            htmlContent += 'Dashboard';
            htmlContent += '</a>';
            htmlContent += '</li>';
            debugger;
            if (menuArr.length > 0) {
                for (var mainMenuItem in menuArr) {
                    htmlContent += "<li>";
                    htmlContent += '<a data-toggle="dropdown" data-hover="dropdown" data-close-others="true" class="dropdown-toggle" href="' + menuArr[mainMenuItem].Path + '">';
                    htmlContent += '<span class="selected"></span>';
                    htmlContent += '' + menuArr[mainMenuItem].Name + '';
                    htmlContent += '<i class="icon-angle-down"></i>';
                    htmlContent += '</a>';
                    htmlContent += "<ul class='dropdown-menu'>";
                    if (subMenuArr.length > 0) {
                        for (var item in subMenuArr) {
                            if (menuArr[mainMenuItem].Id == subMenuArr[item].ParentId) {
                                htmlContent += '<li>';
                                htmlContent += '<a href="' + subMenuArr[item].Path + '">';
                                htmlContent += '<span class="badge-roundless badge-important"></span>' + subMenuArr[item].Name
                                htmlContent += '</a>';
                                htmlContent += '</li>';
                            }
                        }
                    }
                    htmlContent += '</ul>';
                    htmlContent += "</li>";
                }
            }
            htmlContent += "</ul>";
            $("#MenuModule").html(htmlContent);

        });
    });
