Pronto supports OpenID for authentication.
The file `~/App_Data/authorization.xml` contains the OpenIDs that can edit the website.
```
<?xml version="1.0" encoding="utf-8"?>
<authorization>
  <admin id="http://andrewdavey.myopenid.com/" name="Andrew D." />
</authorization>
```

The login dialog box also has a link to "Log in with Google". So if you have a Google account  you can log in with out typing anything. However, your Google OpenID will be different for each domain name you are authenticating for. This makes setting up your admin status in authorization.xml a little tricky!

Click the "Log in with Google" link anyway! You will be authenticated still, but not authorized. Now view the page source. The cms javascript object will contain your OpenID. Copy this into the authorization.xml file. Then reload the page, you should now see the admin UI.

Make sure your website server runs on the same port while developing. If using IIS  shouldn't be a problem, but the Visual Studio Development Server can randomly choose ports. This means Google returns a different OpenID. Open you web project properties, select the Web tab. Click the option for "Specific Port".