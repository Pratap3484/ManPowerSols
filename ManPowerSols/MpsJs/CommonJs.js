/**
Author :Pratap k.
Date : 18/04/2019

**/





// Read a page's GET URL variables and return them as an associative array.
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

if (sessionStorage.getItem("usermailid") == null) {
    var url = window.location.href.split('/')[0]
    window.location.href = url + '/Home/Index';
}
$('#spnusername,#h2username,#h6username').text(sessionStorage.getItem('name'))
//last login details binding
var logindetails = sessionStorage.getItem('lastlogidetails')
$('#lastlogindate').text(logindetails.toString().split(' ')[0])
$('#lastloginmonthyear').text(logindetails.toString().split(' ')[1] + ' ' + logindetails.toString().split(' ')[2])
$('#lastloginday').text(logindetails.toString().split(' ')[3]);

$('.cmpny').text(sessionStorage.getItem('comapany'))
if (sessionStorage.getItem('usertype') == '2')
    $('#spnusertype').text('Agent')
else if (sessionStorage.getItem('usertype') == '3')
    $('#spnusertype').text('Employer')

function getcountrylist(cntrl) {
    $.ajax({
        //url: '@Url.Action("GetCountryList", "Home")',
        url: '/Home/GetCountryList',
        type: 'POST',
        data: JSON.stringify(),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (res) {
            if (res.ResponseCode == "200") {
                var mySelect = $('#' + cntrl);
                mySelect.empty()
                mySelect.append($('<option></option>').val('').html('Select Country'))
                $.each(res.ResponseList.countrylist, function (i, item) {
                    mySelect.append(
                        $('<option></option>').val(item.id).html(item.CountryName)
                    );
                });
            }
            else if (res.ResponseCode == "100") {
                alert('something went wrong! Please try again.')
            }

            else {

                alert('Error : Status Code: ' + res.ResponseCode + '. Messsage' + res.ResponseMessage)
            }
            //$('#divLoader').modal('hide');
        },

        error: function (err) {

        }
    });
}

function getstatelist(countryid, cntrl) {
    var jp = {};
    jp.CountryID = countryid;
    $.ajax({
        url: '/Home/GetStatesbyCountry',
        type: 'POST',
        data: JSON.stringify(jp),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (res) {
            if (res.ResponseCode == "200") {
                var mySelect = $('#' + cntrl);
                mySelect.empty()
                mySelect.append($('<option></option>').val('').html('Select State'))
                $.each(res.ResponseList.statelist, function (i, item) {
                    mySelect.append(
                        $('<option></option>').val(item.id).html(item.StateName)
                    );
                });
            }
            else if (res.ResponseCode == "100") {
                alert('something went wrong! Please try again.')
            }

            else {

                alert('Error : Status Code: ' + res.ResponseCode + '. Messsage' + res.ResponseMessage)
            }
            //$('#divLoader').modal('hide');
        },

        error: function (err) {

        }
    });
}

function getcitieslist(stateid, cntrl) {
    var jp = {};
    jp.StateID = stateid;
    $.ajax({
        url: '/Home/GetCitiesbyState',
        type: 'POST',
        data: JSON.stringify(jp),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (res) {
            if (res.ResponseCode == "200") {
                var mySelect = $('#' + cntrl);
                mySelect.empty()
                mySelect.append($('<option></option>').val('').html('Select City'))
                $.each(res.ResponseList.citylist, function (i, item) {
                    mySelect.append(
                        $('<option></option>').val(item.id).html(item.CityName)
                    );
                });
            }
            else if (res.ResponseCode == "100") {
                alert('something went wrong! Please try again.')
            }

            else {

                alert('Error : Status Code: ' + res.ResponseCode + '. Messsage' + res.ResponseMessage)
            }
            //$('#divLoader').modal('hide');
        },

        error: function (err) {

        }
    });
}

function editJob(recid) {
    var jp = {};
    jp.Rec_ID = recid;
    $.ajax({
        url: '/EmpViewPosts/EditJobDetails',
        type: 'POST',
        data: JSON.stringify(jp),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (res) {
            if (res.ResponseCode == "200") {
                $('#divJobsgrid').hide()
                $('#divupdatejobdetails').show()
                getcountrylist('ddlcountry')
                bindJobDetails(res.ResponseList.joblist)
            }
            else if (res.ResponseCode == "100") {
                alert('something went wrong! Please try again.')
            }
            else {
                alert('Error : Status Code: ' + res.ResponseCode + '. Messsage' + res.ResponseMessage)
            }
        },

        error: function (err) {

        }
    });
}

function sleep(sleepDuration) {
    var now = new Date().getTime();
    while (new Date().getTime() < now + sleepDuration) { /* do nothing */ }
}
//method to get the job details for apply 
function jobfulldetails(jobid) {
    //$('#divJobdetails').modal('show')
    var jd = {};
    jd.Rec_ID = jobid;

    $.ajax({
        url: '/Home/GetJobDetailsbyID',
        type: 'POST',
        data: JSON.stringify(jd),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (res) {

            if (res.ResponseCode == "200") {
                $('#lblcompname').text(res.ResponseList.joblist[0].CompanyName)
                $('#lbljobtitle').text(res.ResponseList.joblist[0].Post_Title)
                $('#lblsector').text(res.ResponseList.joblist[0].Post_Category)
                $('#lblopenings').text(res.ResponseList.joblist[0].NoOfEmp)
                $('#lblexp').text(res.ResponseList.joblist[0].Emp_experince)
                $('#lbltimings').text(res.ResponseList.joblist[0].FromTime + '-' + res.ResponseList.joblist[0].ToTime)
                $('#lblcontractperiod').text(res.ResponseList.joblist[0].ContractPeriod + ' ' + res.ResponseList.joblist[0].ContractType)
                $('#lblworklocation').text(res.ResponseList.joblist[0].WorkLocation)
                $('#lblRecId').text(res.ResponseList.joblist[0].Rec_ID)

                $('#lblposteddate').text(res.ResponseList.joblist[0].Entdt)
                $('#lbltransport').text(res.ResponseList.joblist[0].TransaposrtFacility == 'null' ? 'No' : res.ResponseList.joblist[0].TransaposrtFacility)
                $('#lblwagedetails').text(res.ResponseList.joblist[0].CurrencyType + '-' + res.ResponseList.joblist[0].Amount)
                $('#lbladdress').text(res.ResponseList.joblist[0].Country + ', ' + res.ResponseList.joblist[0].State + ', ' + res.ResponseList.joblist[0].City + ', ' + res.ResponseList.joblist[0].ZipCode)

                $('#mdlJobdetails').modal('show');
                //$('#mdlJobdetails').show();
            }
            else {
            }

        },
        error: function (err) {
            // $('#divLoader').modal('hide');
        }
    });
}

function bindJobDetails(data) {
    $('#txtjobtitle').val(data[0].Post_Title);
    $('#ddlcategory').val(data[0].Post_Category);
    if (data[0].Post_Category == 'Others') {
        $('#txtothers').show();
        $('#txtothers').val(data[0].Other);
    }
    $('#txtrecid').val(data[0].Rec_ID);
    $('#txtuserid').val(data[0].UserID);
    $('#txtrectype').val(data[0].RecordType);
    $('#txtrecaccessstatus').val(data[0].Access_status);
    $('#txtnoemps').val(data[0].NoOfEmp);
    $('#txtcompany').val(data[0].CompanyName);
    $('#txtempexp').val(data[0].Emp_experince);
    //$('#ddltimings').val(data[0].shifttimings);
    // $('#ddlcontractperiod').val(data[0].ContractPeriod);
    $('#txtfromtime').val(data[0].FromTime);
    $('#txttotime').val(data[0].ToTime);
    $('#ddlcontractperiodtype').val(data[0].ContractType);
    $('#txtcontractperiod').val(data[0].ContractPeriod);
    $("#txtworkloc").val(data[0].WorkLocation);
    $('#txtdescmsg').val(data[0].post_comments)
    $('#ddltrsprt').val(data[0].TransaposrtFacility);
    $('#txtzipcode').val(data[0].ZipCode);
    $('#ddlpaytype').val(data[0].PaymentType);
    $('#txtamount').val(data[0].Amount);
    $('#txtcurrencytype').val(data[0].CurrencyType);

    setTimeout(function () { $("#ddlcountry option:contains('" + data[0].Country + "')").attr('selected', 'selected'); getstatelist($("#ddlcountry :selected").val(), 'ddlstate'); }, 5000);
    setTimeout(function () { $("#ddlstate option:contains('" + data[0].State + "')").attr('selected', 'selected'); getcitieslist($("#ddlstate :selected").val(), 'ddlcity'); }, 8000);
    setTimeout(function () { $("#ddlcity option:contains('" + data[0].City + "')").attr('selected', 'selected') }, 10000);
}

function readbase64File() {
    if (this.files && this.files[0]) {

        var FR = new FileReader();
        FR.addEventListener("load", function (e) {
            document.getElementById("profileimg").src = e.target.result;
            //document.getElementById("b64").innerHTML = e.target.result;
            $('#base64data').val(e.target.result.split(',')[1])
            // alert(e.target.result.split(',')[1]);
        });
        FR.readAsDataURL(this.files[0]);
    }

}

//click event to apply button doe the employer,agent and user
$('#btnApplyJob').click(function (e) {
    if (parseInt($('#txtnoofemps').val()) > parseInt($('#lblopenings').text())) {
        alert('Given number of Employer are greater than the openings')
        return false;
    }
    else {
        var um = {};
        um.JobID = $('#lblRecId').text();
        um.NoOfEmp = $('#txtnoofemps').val() == '' ? '1' : $('#txtnoofemps').val();
        um.UserID = sessionStorage.getItem('usermailid');
        um.post_comments = $('#tacomments').val();
        um.UserType = sessionStorage.getItem('usertype');
        um.Other = $('#taothermsg').val();
        um.Access_status = "";
        console.log(um)
        $.ajax({
            url: '/start/Start/ApplyJob',
            type: 'POST',
            data: JSON.stringify(um),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (res) {
                if (res.ResponseCode == "200") {
                    alert('Job applied successfully')
                    $('#mdlJobdetails').modal('hide');
                }

                else {
                    alert(res.ResponseMessage)
                    $('#mdlJobdetails').modal('hide');
                }
            },
            error: function (err) {
                $('#mdlJobdetails').modal('hide');

            }
        });
    }
})

//function to get today date
function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
function getMonthName(size) {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    return months[size];
}

function getweekday() {
    var days = [
    'Sunday',
    'Monday',
    'Tuesday',
    'Wednesday',
    'Thursday',
    'Friday',
    'Saturday'
    ];
    d = new Date();
    x = d.getDay();
    return days[x];
}
function getTodayDate() {
    var d = new Date();
    var day = addZero(d.getDate());
    //var month = addZero(d.getMonth() + 1);
    var month = d.getMonth();
    var year = addZero(d.getFullYear());
    return day + "/" + getMonthName(month) + " " + year;
}
$('#todaylogindate').text(getTodayDate().split('/')[0])
$('#todayloginmonthyear').text(getTodayDate().split('/')[1])
$('#todayloginday').text(getweekday());


