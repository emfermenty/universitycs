CREATE TABLE author(
	id serial PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	biography TEXT
);
CREATE TABLE category(
	id serial PRIMARY KEY,
	name varchar(255) NOT NULL
);

CREATE TABLE post(
	id serial PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	description TEXT NOT NULL,
	author_id integer NOT NULL,
	post_rating integer DEFAULT 0 NOT NULL,
	FOREIGN KEY (author_id) REFERENCES author(id)
);

CREATE TABLE post_category(
	post_id integer,
	category_id integer,
	PRIMARY KEY(post_id, category_id),
	FOREIGN KEY(post_id) REFERENCES post(id),
	FOREIGN KEY(category_id) REFERENCES category(id)
);