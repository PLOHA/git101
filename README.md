https://drive.google.com/drive/folders/1kmQYPsQ4khq0kxqqsLHEHe-9Ovs9jaRR?usp=sharing
รูปภาพโดยรวมของโปรเจค / Exxample Photos for preview.
Details From LOHA's : Asp.net8 core Web API + AdminLTE for prob  


Enforced Login & Custom Login UI
I have secured the application by enforcing login globally and redesigned the login page with a premium Black & Red theme.

Changes Implemented
1. Global Authentication Enforcement
File: 

Program.cs
Change: Added a global initialization filter that requires all users to be authenticated.
Effect: Any attempt to access any page (like /Home/Index) without being logged in will automatically redirect the user to the Login page.
2. Custom Login Page (Black & Red Design)
File: 

Areas/Identity/Pages/Account/Login.cshtml
Design:
Background: Pure Black (#000000).
Card: Dark Grey (#1a1a1a) with a glowing Red (#d60000) top border and shadow.
Buttons: Red primary buttons that glow on hover.
Inputs: Dark theme inputs.
Backend: Implemented standard ASP.NET Identity logic in 

Login.cshtml.cs
 to handle sign-in, "Remember Me", and errors. Added [AllowAnonymous] to prevent redirect loops.
3. Bug Fix: Redirect Loop
Issue: The global authentication filter caused an infinite redirect loop because the 

Login
 page itself required authentication.
Fix: Added [AllowAnonymous] attribute to 

LoginModel
 in 

Areas/Identity/Pages/Account/Login.cshtml.cs
.
Result: The Login page is now publicly accessible, breaking the loop.
4. UI/UX Redesign (Premium Dark Theme)
Theme: Created 

wwwroot/css/premium-theme.css
 overriding AdminLTE with a modern GitHub-style dark mode and red accents.
Navbar: Replaced standard icons with a custom-styled "Logout" button (Gradient Red).
Global: Applied dark-mode to <body> in 

_Layout.cshtml
.
