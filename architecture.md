Example query:-
```
create {
	type db
	name test_db
}

update {
	type session
	db test_db
}

create {
	type table
	name test_table
	schema {
		id {
			type number
			primary yes
			unique yes -*- can be omitted, primary always unique
			default 1 -*- if default set to non-null, nullable is always no
			increment 1
		}
		test_name {
			type string
			-*- primary omitted, by default set to no
			unique yes
			max_length 100
			-*- if default not set, always nullable
		}
		update_dttm {
			type datetime
		}
	}
}

update {
	type table
	name test_table
	add {
		create_dttm {
			type datetime -*- can also be just date
			-*- unique, primary not allowed for date/datetime
		}
	}
	remove {
		update_dttm
	}
}

read {
	type table
	name test_table
} -*- fetches the above schema + other info

create {
	type record
	name test_table
	values {
		test_name "name"
		create_dttm (today() + days(10))
	}
}

update {
	type record
	name test_table
	values {
		create_dttm (today() + days(2))
	}
	where {
		id > 0
	}
}

read {
	type record -*- if not mentioned, implicitly fetch table
	name test_table
} -*- fetches all records and columns from test_table

read {
	type table
	name test_table
	column {
		id
		test_name
		create_dttm {
			as dttm
			return {
				value + days(1)
			}
		}
	}
	where {
		-*- all conditions are always AND
		-*- inside paranthesis, you can have AND/OR
		(id > 0 | id < 100 & create_dttm > (today() - days(10)))
		(create_dttm != today())
	}
}

delete {
	type record
	name test_table
	where {
		(id > 0)
	}
}

delete {
	type table
	name test_table
}
```

# Reserved keywords
* create
* update
* read
* delete
* db
* session
* name
* table
* column
* row
* schema