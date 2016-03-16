;#DropDB RecruitmentEasyTest

#Application Recruitment.Win
#Application Recruitment.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef Recruitment.Win

*Action About...
 
*Action OK

#EndIf

#IfDef Recruitment.Web
*Action Navigation(My Details)
#EndIf
