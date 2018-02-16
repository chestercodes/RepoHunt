sqlite3 "C:\Dev\Data\RepoHunt\RepoHunt.db"

.mode csv
.output "C:\\Dev\\Data\\RepoHunt\\npm\\results\\AuthorsAggLevDistLte1.csv"
select author, count(*) as c from (
	select distinct package from (
		select distinct second as package from npm_edit_distances e
		inner join (select * from npm_interesting_packages where description = 'PopularPackageName') p 
		on e.first = p.package
		where e.distance < 2
		
		union all
		
		select distinct first from npm_edit_distances e
		inner join (select * from npm_interesting_packages where description = 'PopularPackageName') p 
		on e.second= p.package
		where e.distance < 2
	)
) pAll
inner join npm_authors a
on a.package = pAll.package
where pAll.package not in (
	select distinct package from npm_interesting_packages where description = 'PopularPackageName'
)
group by author
order by c desc;
.output stdout

.output "C:\\Dev\\Data\\RepoHunt\\npm\\results\\AuthorsAggLevDistLte2.csv"
select author, count(*) as c from (
	select distinct package from (
		select distinct second as package from npm_edit_distances e
		inner join (select * from npm_interesting_packages where description = 'PopularPackageName') p 
		on e.first = p.package
		where e.distance < 2
		
		union all
		
		select distinct first from npm_edit_distances e
		inner join (select * from npm_interesting_packages where description = 'PopularPackageName') p 
		on e.second= p.package
		where e.distance < 2
	)
) pAll
inner join npm_authors a
on a.package = pAll.package
where pAll.package not in (
	select distinct package from npm_interesting_packages where description = 'PopularPackageName'
)
group by author
order by c desc;
.output stdout