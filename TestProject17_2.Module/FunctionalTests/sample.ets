;#DropDB TestProject17_2EasyTest

#Application TestProject17_2.Win
#Application TestProject17_2.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef TestProject17_2.Win

*Action About...
 
*Action OK

#EndIf

#IfDef TestProject17_2.Web
*Action Navigation(My Details)
#EndIf
