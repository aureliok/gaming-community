DROP TABLE IF EXISTS community_data.votes;
DROP TABLE IF EXISTS community_data.comments;
DROP TABLE IF EXISTS community_data.threads;
DROP TABLE IF EXISTS community_data.user_profiles;
DROP TABLE IF EXISTS community_data.game_reviews;
DROP TABLE IF EXISTS community_data.games;
DROP TABLE IF EXISTS community_data.developers;
DROP TABLE IF EXISTS community_data.publishers;
DROP TABLE IF EXISTS community_data.content_ratings;
DROP TABLE IF EXISTS community_data.user_connections;
DROP TABLE IF EXISTS community_data.inbox_messages;
DROP TABLE IF EXISTS community_data.platforms;
DROP TABLE IF EXISTS community_data.genres;
DROP TABLE IF EXISTS community_data.users;
DROP TABLE IF EXISTS community_data.user_levels;


CREATE TABLE community_data.user_levels (
	level_id SERIAL PRIMARY KEY
	,user_level VARCHAR(20) NOT NULL DEFAULT 'user' 
);

CREATE TABLE community_data.users (
	user_id SERIAL PRIMARY KEY
	,username VARCHAR(50) UNIQUE NOT NULL
	,email VARCHAR(100) NOT NULL
	,password_hash VARCHAR(20) NOT NULL
	,level_id INT NOT NULL REFERENCES community_data.user_levels(level_id)
);

CREATE TABLE community_data.threads (
	thread_id SERIAL PRIMARY KEY
	,title VARCHAR(255) NOT NULL
	,content TEXT
	,created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
	,user_id INT REFERENCES community_data.users(user_id)
);

CREATE TABLE community_data.comments (
	comment_id SERIAL PRIMARY KEY
	,content TEXT NOT NULL
	,created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
	,user_id INT REFERENCES community_data.users(user_id)
	,thread_id INT REFERENCES community_data.threads(thread_id)
);

CREATE TABLE community_data.votes (
	vote_id SERIAL PRIMARY KEY
	,vote_type VARCHAR(5) NOT NULL CHECK (vote_type IN ('upvote', 'downvote'))
	,user_id INT REFERENCES community_data.users(user_id)
	,thread_id INT REFERENCES community_data.threads(thread_id)
	,comment_id INT REFERENCES community_data.comments(comment_id)
);

CREATE TABLE community_data.user_profiles (
	user_id SERIAL PRIMARY KEY REFERENCES community_data.users(user_id)
	,bio TEXT
	,avatar_id VARCHAR(24) DEFAULT NULL
	,gaming_platform_link VARCHAR(50)
);

CREATE TABLE community_data.genres (
	genre_id SERIAL PRIMARY KEY
	,genre VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE community_data.platforms (
	platform_id SERIAL PRIMARY KEY
	,platform VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE community_data.developers (
	developer_id SERIAL PRIMARY KEY
	,developer VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE community_data.publishers (
	publisher_id SERIAL PRIMARY KEY
	,publisher VARCHAR(20)
);

CREATE TABLE community_data.content_ratings (
	content_rating_id SERIAL PRIMARY KEY
	,content_rating VARCHAR(5) UNIQUE NOT NULL
);

CREATE TABLE community_data.games (
	game_id SERIAL PRIMARY KEY
	,title VARCHAR(60)
	,release_date DATE
	,genre_id INT NOT NULL REFERENCES community_data.genres(genre_id)
	,platform_id INT NOT NULL REFERENCES community_data.platforms(platform_id)
	,developer_id INT NOT NULL REFERENCES community_data.developers(developer_id)
	,publisher_id INT NOT NULL REFERENCES community_data.publishers(publisher_id)
	,content_rating_id INT NOT NULL REFERENCES community_data.content_ratings(content_rating_id)
	,image_id VARCHAR(24) DEFAULT NULL
);

CREATE TABLE community_data.game_reviews (
	review_id SERIAL PRIMARY KEY
	,game_id INT NOT NULL REFERENCES community_data.games(game_id)
	,user_id INT NOT NULL REFERENCES community_data.users(user_id)
	,score INT NOT NULL CHECK (score in (1, 2, 3, 4, 5))
	,review_text TEXT
);

CREATE TABLE community_data.user_connections (
	connection_id SERIAL PRIMARY KEY
	,user_id INT NOT NULL REFERENCES community_data.users(user_id)
	,friend_id INT NOT NULL REFERENCES community_data.users(user_id)
	,connection_type VARCHAR(15) CHECK (connection_type in ('friend', 'follower', 'following'))
	,connection_start DATE DEFAULT CURRENT_DATE
	,connection_end DATE 
);

CREATE TABLE community_data.inbox_messages (
	message_id SERIAL PRIMARY KEY
	,sender_id INT NOT NULL REFERENCES community_data.users(user_id)
	,recipient_id INT NOT NULL REFERENCES community_data.users(user_id)
	,message_text VARCHAR(400)
	,created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


