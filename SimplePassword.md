In web.config set the "auth-type" appSetting to be "SimplePassword".
Add another appSetting `<add key="password" value="secretfoo"/>`

Admins can now log-in using the simple password. They can also change it once logged in using the in-page admin UI.

Yeah, it not very secure, but it is very, very _simple_!!