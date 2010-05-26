var popUp; 

function OpenCalendar(idname, postBack)
{
    //alert(eval('document.aspnetForm.ctl00$ContentPlaceHolder1$' + idname + '.value'));
    var valor=eval('document.aspnetForm.ctl00$ContentPlaceHolder1$' + idname + '.value');
   //lo dejamos fijo por el contenedor de la master page
   var nombreFormulario='aspnetForm';
   
    
	popUp = window.open('../../includes/calendar/Calendar.aspx?formname=' + nombreFormulario + 
		'&id=' + idname + '&selected=' + valor + '&postBack=' + postBack, 
		'popupcal', 
		'width=160,height=238,left=200,top=250');
}

function SetDate(formName, id, newDate, postBack)
{
	eval('var theform = document.aspnetForm ;');
	eval('var objeto = document.aspnetForm.ctl00$ContentPlaceHolder1$' + id + ';');
	popUp.close();
	objeto.value = newDate;
	if (postBack)
		__doPostBack(id,'');
}		
