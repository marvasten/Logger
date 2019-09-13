# Add environment variables
[Environment]::SetEnvironmentVariable("ConnectionString", "Data Source=MARCO-VASQUEZ\SQLEXPRESS;initial catalog=Logger;Integrated Security=True", "User")
[Environment]::SetEnvironmentVariable("LogFileDirectory", "C:\LogFiles", "User")

# Delete environment variables
[Environment]::SetEnvironmentVariable("ConnectionString", $null, "User")
[Environment]::SetEnvironmentVariable("LogFileDirectory", $null, "User")

