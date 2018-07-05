;#DropDB SampleProjectEasyTest

#Application SampleProject.Win
#Application SampleProject.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef SampleProject.Win

*Action About...
 
*Action OK

#EndIf

#IfDef SampleProject.Web
*Action Navigation(My Details)
#EndIf
