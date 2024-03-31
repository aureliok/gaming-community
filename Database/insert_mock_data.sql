INSERT INTO community_data.user_levels (user_level) VALUES
    ('User')
    ,('Super User')
    ,('Admin');

INSERT INTO community_data.users (username, email, password_hash, level_id) VALUES
    ('user1', 'user1@example.com', '$2a$11$bdHY56Ohiy2dEgQCuOchZOFKetK5pxJ8fVcp8JyUVv2fz//6gINa.', 1)
    ,('user2', 'user2@example.com', '$2a$11$bg7zO8trpOGFib2zFl6B5uKYUf7bME/Jfmo5DG1fqCmeDnhPRDjBC', 1)
    ,('user3', 'user3@example.com', '$2a$11$cRTNx5QSqek6I7BzIkbSa.7wLBwtRl.khsp/SICbIl0IWd1wxcSra', 1)
    ,('user4', 'user4@example.com', '$2a$11$07IwARZVOIMex4kpiVPXpucEybxl5Bx/3vJWX7EH5v8sOE4L6FpoO', 1)
    ,('user5', 'user5@example.com', '$2a$11$3bJZonAy7Mz1YuEPw5g4a.g86IGdRipEbHqdtseEnm533Y.g9mvZe', 1)
    ,('superuser1', 'superuser1@example.com', '$2a$11$RVIyryWfZTMQlFsxVQ0hve8axVbs./H2GEyAPkIXVBL5FIq0uKts2', 2)
    ,('superuser2', 'superuser2@example.com', '$2a$11$96d9qa/c0zdGLLIkjkp2uOe5inS.68hOvNtqNcXHpRaznQJ1/s9Ea', 2)
    ,('superuser3', 'superuser3@example.com', '$2a$11$BU.wgGkvFp.7rL9K0/kxquSaW1lmThwCZs7nInc7MfCS3r//W/Boe', 2)
    ,('admin1', 'admin1@example.com', '$2a$11$7NZDxUW.y7VaH4OmUw4ReO5el/otrv3PTLv8LQuZAYMnutdn0tjCu', 3)
    ,('admin2', 'admin2@example.com', '$2a$11$c5eQGdBBUdsOsZzZWVPSZOXbUP1wR.9qwDnsm7E0sxBStVqQhR7Um', 3);


INSERT INTO community_data.threads (title, content, created_at, user_id) VALUES
    ('Thread 1', 'Content for thread 1', CURRENT_TIMESTAMP - INTERVAL '1 hour', 1)
    ,('Thread 2', 'Content for thread 2', CURRENT_TIMESTAMP - INTERVAL '4 hours', 2)
    ,('Thread 3', 'Content for thread 3', CURRENT_TIMESTAMP - INTERVAL '2 hours', 3)
    ,('Thread 4', 'Content for thread 4', CURRENT_TIMESTAMP - INTERVAL '4 hours', 4)
    ,('Thread 5', 'Content for thread 5', CURRENT_TIMESTAMP - INTERVAL '12 hours', 5)
    ,('Thread 6', 'Content for thread 6', CURRENT_TIMESTAMP - INTERVAL '6 hours', 1)
    ,('Thread 7', 'Content for thread 7', CURRENT_TIMESTAMP - INTERVAL '7 hours', 2)
    ,('Thread 8', 'Content for thread 8', CURRENT_TIMESTAMP - INTERVAL '20 hours', 3)
    ,('Thread 9', 'Content for thread 9', CURRENT_TIMESTAMP - INTERVAL '9 hours', 4)
    ,('Thread 10', 'Content for thread 10', CURRENT_TIMESTAMP - INTERVAL '10 hours', 5);


INSERT INTO community_data.comments (content, created_at, user_id, thread_id) VALUES
    ('Comment 1', CURRENT_TIMESTAMP - INTERVAL '2 hours', 2, 1)
    ,('Comment 2', CURRENT_TIMESTAMP - INTERVAL '4 hours', 10, 2)
    ,('Comment 3', CURRENT_TIMESTAMP - INTERVAL '6 hours', 3, 3)
    ,('Comment 4', CURRENT_TIMESTAMP - INTERVAL '1 hour', 4, 7)
    ,('Comment 5', CURRENT_TIMESTAMP - INTERVAL '8 hours', 6, 5)
    ,('Comment 6', CURRENT_TIMESTAMP - INTERVAL '4 hours', 1, 1)
    ,('Comment 7', CURRENT_TIMESTAMP - INTERVAL '5 hours', 7, 10)
    ,('Comment 8', CURRENT_TIMESTAMP - INTERVAL '12 hours', 3, 2)
    ,('Comment 9', CURRENT_TIMESTAMP - INTERVAL '3 hours', 9, 4)
    ,('Comment 10', CURRENT_TIMESTAMP - INTERVAL '10 hours', 5, 2);



INSERT INTO community_data.user_profiles (user_id, bio, avatar_id, gender, birth_date, gaming_platform_link) VALUES
    (1, 'I love gaming!', 'randomstring', 'F', '2000-01-03', 'https://example.com/platform1')
    ,(2, 'Gamer for life!', 'randomstring222', 'M', '1995-05-06', 'https://example.com/platform2')
    ,(3, 'Gaming is my passion', 'soqksoqp', 'Other', '1980-04-20', 'https://example.com/platform3')
    ,(4, 'Professional gamer', 'djsadj', 'F','1999-12-28', 'https://example.com/platform4')
    ,(5, 'Gaming enthusiast', 'dsadapop', 'M','1989-08-01', 'https://example.com/platform5')
    ,(6, 'Casual gamer', 'M', 'kpkepo', '1975-06-03', 'https://example.com/platform6')
    ,(7, 'Competitive gamer', 'djasdjao', 'M','2002-02-03', 'https://example.com/platform7')
    ,(8, 'Gamer geek', 'dsjdaso', 'Other','2001-03-03', 'https://example.com/platform8')
    ,(9, 'Gaming addict', 'mkmkmkm', 'F', '1960-01-01', 'https://example.com/platform9')
    ,(10, 'Gaming for fun', 'jdijodawjdo', 'M', '1996-10-12', 'https://example.com/platform10');


INSERT INTO community_data.genres (genre) VALUES
    ('Action')
    ,('Adventure')
    ,('RPG')
    ,('Strategy')
    ,('Simulation')
    ,('Sports')
    ,('Puzzle')
    ,('Horror')
    ,('Fighting')
    ,('Platformer');


INSERT INTO community_data.platforms (platform) VALUES
    ('PC')
    ,('PlayStation 4')
    ,('Xbox One')
    ,('Nintendo Switch')
    ,('iOS')
    ,('PlayStation 5')
    ,('Xbox Series X')
    ,('Nintendo 3DS')
    ,('Android')
    ,('Xbox 360');


INSERT INTO community_data.developers (developer) VALUES
    ('Rockstar Games')
    ,('Naughty Dog')
    ,('Ubisoft')
    ,('Bethesda Game Studios')
    ,('Nintendo')
    ,('CD Projekt Red')
    ,('Epic Games')
    ,('Capcom')
    ,('Square Enix')
    ,('Valve Corporation');


INSERT INTO community_data.publishers (publisher) VALUES
    ('Electronic Arts')
    ,('Activision')
    ,('Square Enix')
    ,('Nintendo')
    ,('Ubisoft')
    ,('Sony Interactive Entertainment')
    ,('Capcom')
    ,('Bandai Namco Entertainment')
    ,('Microsoft Studios')
    ,('Sega');


INSERT INTO community_data.content_ratings (content_rating) VALUES
    ('EC - Early Childhood')
    ,('E - Everyone')
    ,('E10+ - Everyone 10+')
    ,('T - Teen')
    ,('M - Mature')
    ,('AO - Adults Only')
    ,('RP - Rating Pending');


INSERT INTO community_data.games (title, release_date, genre_id, platform_id, developer_id, publisher_id, content_rating_id, image_id) VALUES
    ('The Witcher 3: Wild Hunt', '2015-05-19', 3, 1, 6, 1, 5, '507f1f77bcf86cd799439011')
    ,('The Legend of Zelda: Breath of the Wild', '2017-03-03', 2, 4, 5, 5, 3, '507f1f77bcf86cd799439012')
    ,('Grand Theft Auto V', '2013-09-17', 1, 2, 1, 1, 5, '507f1f77bcf86cd799439013')
    ,('Red Dead Redemption 2', '2018-10-26', 1, 2, 1, 1, 5, '507f1f77bcf86cd799439014')
    ,('Final Fantasy VII Remake', '2020-04-10', 3, 2, 8, 8, 5, '507f1f77bcf86cd799439015')
    ,('The Last of Us Part II', '2020-06-19', 1, 2, 2, 2, 5, '507f1f77bcf86cd799439016')
    ,('Animal Crossing: New Horizons', '2020-03-20', 2, 4, 5, 5, 1, '507f1f77bcf86cd799439017')
    ,('Fortnite', '2017-07-25', 1, 5, 7, 7, 1, '507f1f77bcf86cd799439018')
    ,('Minecraft', '2011-11-18', 6, 1, 10, 10, 2, '507f1f77bcf86cd799439019')
    ,('Call of Duty: Warzone', '2020-03-10', 1, 2, 1, 1, 5, '507f1f77bcf86cd799439020');


INSERT INTO community_data.game_reviews (game_id, platform_id, user_id, score, review_text, created_at) VALUES
    (1, 1, 1, 5, 'Absolutely loved this game, one of the best RPGs ever!', CURRENT_TIMESTAMP - INTERVAL '1 hour')
    ,(2, 4, 2, 4, 'A fantastic open-world game with breathtaking visuals.', CURRENT_TIMESTAMP - INTERVAL '5 hours')
    ,(3, 2, 3, 5, 'GTA V offers an immersive experience with its diverse gameplay.', CURRENT_TIMESTAMP - INTERVAL '7 hours')
    ,(4, 2, 4, 5, 'An epic Western adventure with an engrossing story.', CURRENT_TIMESTAMP - INTERVAL '2 hours')
    ,(5, 1, 5, 5, 'The remake captures the essence of the original while adding new elements.', CURRENT_TIMESTAMP - INTERVAL '12 hours')
    ,(6, 1, 6, 4, 'A masterpiece in storytelling, but the gameplay could be improved.', CURRENT_TIMESTAMP - INTERVAL '14 hours')
    ,(7, 3, 7, 5, 'A charming and relaxing game, perfect for unwinding.', CURRENT_TIMESTAMP - INTERVAL '20 hours')
    ,(8, 4, 8, 3, 'Fortnite is fun, but the constant updates can be overwhelming.', CURRENT_TIMESTAMP - INTERVAL '3 hours')
    ,(9, 1, 9, 5, 'Minecraft offers endless creativity and exploration.', CURRENT_TIMESTAMP - INTERVAL '4 hours')
    ,(10, 1, 10, 4, 'Warzone delivers intense multiplayer action, but suffers from cheaters.', CURRENT_TIMESTAMP - INTERVAL '5 hours');


INSERT INTO community_data.user_connections (user_id, friend_id, connection_type, connection_start, connection_end) VALUES
    (1, 2, 'friend', '2023-01-01', '2023-12-25')
    ,(1, 3, 'follower', '2023-02-15', NULL)
    ,(2, 3, 'friend', '2023-03-20', NULL)
    ,(3, 4, 'following', '2023-04-10', '2023-05-12')
    ,(4, 5, 'follower', '2023-05-05', NULL)
    ,(5, 6, 'following', '2023-06-10', NULL)
    ,(6, 7, 'friend', '2023-07-15', NULL)
    ,(7, 8, 'following', '2023-08-20', NULL)
    ,(8, 9, 'follower', '2023-09-25', '2024-01-02')
    ,(9, 10, 'friend', '2023-10-30', NULL);


INSERT INTO community_data.inbox_messages (sender_id, recipient_id, message_text, created_at) VALUES
    (1, 2, 'Hey, how are you?', '2023-01-01 08:00:00')
    ,(2, 1, 'I''m doing great, thanks for asking!', '2023-01-01 08:15:00')
    ,(3, 1, 'Hi there, just wanted to say hello!', '2023-02-01 09:00:00')
    ,(1, 3, 'Hello! How can I help you?', '2023-02-01 09:15:00')
    ,(4, 5, 'What''s up?', '2023-03-01 10:00:00')
    ,(5, 4, 'Not much, just chilling.', '2023-03-01 10:15:00')
    ,(6, 7, 'Hey, let''s catch up sometime!', '2023-04-01 11:00:00')
    ,(7, 6, 'Sure, sounds good!', '2023-04-01 11:15:00')
    ,(8, 9, 'Did you see the latest game announcement?', '2023-05-01 12:00:00')
    ,(9, 8, 'Yes, it looks amazing!', '2023-05-01 12:15:00');


INSERT INTO community_data.votes (vote_type, user_id, thread_id, comment_id, review_id) VALUES
    ('upvote', 1, 1, 1, NULL)
    ,('downvote', 2, 1, NULL, NULL)
    ,('upvote', 3, NULL, 2, NULL)
    ,('downvote', 4, 2, NULL, NULL)
    ,('upvote', 5, 3, NULL, NULL)
    ,('downvote', 1, 3, NULL, NULL)
    ,('upvote', 2, 4, NULL, NULL)
    ,('downvote', 3, 4, NULL, NULL)
    ,('upvote', 4, 5, NULL, NULL)
    ,('downvote', 5, 5, NULL, NULL)
    ,('downvote', 1, NULL, NULL, 1)
    ,('upvote', 1, NULL, NULL, 1);
