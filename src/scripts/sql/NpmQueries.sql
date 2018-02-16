-- agg by author
-- not very useful because tends to just mimic the top publishing users
select author, count(*) as c from (
	select distinct second as package from npm_edit_distances e
	where e.distance < 2
	union all
	select distinct first from npm_edit_distances e
	where e.distance < 2
) pAll
inner join npm_authors a
on a.package = pAll.package
group by author
order by c desc

;

-- agg by author only including the packages where the name is similar to a top package name but not
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
order by c desc

;

