LOG SQL QUERYS TO FILE
	- Add this block inside <entityFramework> block
	<interceptors>
		<interceptor type="System.Data.Entity.Infrastructure.Interception.DatabaseLogger, EntityFramework">
		<parameters>
			<parameter value="c:\temp\EF_Log.txt" />
		</parameters>
		</interceptor>
	</interceptors>


MIGRATIONS
	- To Activate it 
		* From package manager console
			enable-migrations –EnableAutomaticMigration:$true -Force
		* Add this line on context constructor
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Migrations.Configuration>());