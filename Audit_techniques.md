### Варианты реализаций:

1. Реализация на триггерах - исполнение обусловлено действием по модификации данных: добавлением `INSERT`, удалением `DELETE` строки в заданной таблице, или изменением `UPDATE` данных в определенном столбце заданной таблицы реляционной базы данных. Триггер запускается сервером автоматически при попытке изменения данных в таблице, с которой он связан. Все производимые им модификации данных рассматриваются как выполняемые в транзакции, в которой выполнено действие, вызвавшее срабатывание триггера. Соответственно, в случае обнаружения ошибки или нарушения целостности данных может произойти откат этой транзакции.

2. [AuditDbContext](https://auditdbcontext.codeplex.com/) (open source) - An audit record is written whenever an update of delete operation is applied to an entity and stores the time of the change and the user making the change along with the original entity values.
 
3. [Реализация](http://www.exceptionnotfound.net/entity-change-tracking-using-dbcontext-in-entity-framework-6/) трекинга средставами классов `DbChangeTracker` и  `DbEntityEntry` самого EF. 
Недостатки реализации: аудит не ведется для новых сущностей, поддержка только single-column primary keys.

4. [Tracker Enabled DbContext](http://bilal-fazlani.blogspot.ru/2013/09/adding-log-audit-feature-to-entity.htmlhttps://www.nuget.org/packages/TrackerEnabledDbContext) - трекер в репозитории nuget. Хранит данные о том кто, когда и что изменил. Позволяет выбирать таблицы или столбцы для отслеживания.

5. [Реализация](http://www.codeproject.com/Articles/34491/Implementing-Audit-Trail-using-Entity-Framework-Pa) аудита средствами EF, позволяющая откатываться на определенный промежуток времени.

6. [Реализация](http://blogs.msdn.com/b/simonince/archive/2009/04/20/auditing-data-changes-in-the-entity-framework-part-2.aspx) средствами EF.
