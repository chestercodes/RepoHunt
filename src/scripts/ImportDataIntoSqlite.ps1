sqlite3 "C:\Dev\Data\RepoHunt\RepoHunt.db"

.save "C:\Dev\Data\RepoHunt\RepoHunt.db"

.read "./src/scripts/sql/CreateTables.sql"

.separator ","

.import "C:\\Dev\\Data\\RepoHunt\\npm\\Authors.csv" npm_authors

.import "C:\\Dev\\Data\\RepoHunt\\npm\\Counts.csv" npm_name_count

.import "C:\\Dev\\Data\\RepoHunt\\npm\\InterestingPackages.csv" npm_interesting_packages

.import "C:\\Dev\\Data\\RepoHunt\\npm\\Distances.csv" npm_edit_distances
