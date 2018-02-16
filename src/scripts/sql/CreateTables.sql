create table if not exists npm_name_count (
	num_chars int not null,
	count int not null
);

create table if not exists npm_distance_count (
	num_chars int not null,
	distance int not null,
	total int not null,
	count int not null
);

create table if not exists npm_edit_distances (
	distance int not null,
	first text not null,
	len_first int not null,
	second text not null,
	len_second int not null
);

create table if not exists npm_interesting_packages (
	package text not null,
	description text not null
);

create table if not exists npm_authors (
	package text not null,
	author text not null
);

create table if not exists nuget_name_count (
	num_chars int not null,
	count int not null
);

create table if not exists nuget_distance_count (
	num_chars int not null,
	distance int not null,
	total int not null,
	count int not null
);

create table if not exists nuget_edit_distances (
	distance int not null,
	first text not null,
	len_first int not null,
	second text not null,
	len_second int not null
);

create table if not exists pypi_name_count (
	num_chars int not null,
	count int not null
);

create table if not exists pypi_distance_count (
	num_chars int not null,
	distance int not null,
	total int not null,
	count int not null
);

create table if not exists pypi_edit_distances (
	distance int not null,
	first text not null,
	len_first int not null,
	second text not null,
	len_second int not null
);

create table if not exists gem_name_count (
	num_chars int not null,
	count int not null
);

create table if not exists gem_distance_count (
	num_chars int not null,
	distance int not null,
	total int not null,
	count int not null
);

create table if not exists gem_edit_distances (
	distance int not null,
	first text not null,
	len_first int not null,
	second text not null,
	len_second int not null
);

create table if not exists gem_authors (
	package text not null,
	author text not null
);
