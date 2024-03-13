INSERT INTO community_data.user_levels (user_level) VALUES
    ('User')
    ,('Super User')
    ,('Admin');

INSERT INTO community_data.users (username, email, password_hash, level_id) VALUES
    ('user1', 'user1@example.com', 'hashed_password_1', 1)
    ,('user2', 'user2@example.com', 'hashed_password_2', 1)
    ,('user3', 'user3@example.com', 'hashed_password_3', 1)
    ,('user4', 'user4@example.com', 'hashed_password_4', 1)
    ,('user5', 'user5@example.com', 'hashed_password_5', 1)
    ,('superuser1', 'superuser1@example.com', 'hashed_password_6', 2)
    ,('superuser2', 'superuser2@example.com', 'hashed_password_7', 2)
    ,('superuser3', 'superuser3@example.com', 'hashed_password_8', 2)
    ,('admin1', 'admin1@example.com', 'hashed_password_9', 3)
    ,('admin2', 'admin2@example.com', 'hashed_password_10', 3);


INSERT INTO community_data.threads (title, content, created_at, user_id) VALUES
    ('Thread 1', 'Content for thread 1', CURRENT_TIMESTAMP, 1)
    ,('Thread 2', 'Content for thread 2', CURRENT_TIMESTAMP, 2)
    ,('Thread 3', 'Content for thread 3', CURRENT_TIMESTAMP, 3)
    ,('Thread 4', 'Content for thread 4', CURRENT_TIMESTAMP, 4)
    ,('Thread 5', 'Content for thread 5', CURRENT_TIMESTAMP, 5)
    ,('Thread 6', 'Content for thread 6', CURRENT_TIMESTAMP, 1)
    ,('Thread 7', 'Content for thread 7', CURRENT_TIMESTAMP, 2)
    ,('Thread 8', 'Content for thread 8', CURRENT_TIMESTAMP, 3)
    ,('Thread 9', 'Content for thread 9', CURRENT_TIMESTAMP, 4)
    ,('Thread 10', 'Content for thread 10', CURRENT_TIMESTAMP, 5);


INSERT INTO community_data.comments (content, created_at, user_id, thread_id) VALUES
    ('Comment 1', CURRENT_TIMESTAMP, 2, 1)
    ,('Comment 2', CURRENT_TIMESTAMP, 10, 2)
    ,('Comment 3', CURRENT_TIMESTAMP, 3, 3)
    ,('Comment 4', CURRENT_TIMESTAMP, 4, 7)
    ,('Comment 5', CURRENT_TIMESTAMP, 6, 5)
    ,('Comment 6', CURRENT_TIMESTAMP, 1, 1)
    ,('Comment 7', CURRENT_TIMESTAMP, 7, 10)
    ,('Comment 8', CURRENT_TIMESTAMP, 3, 2)
    ,('Comment 9', CURRENT_TIMESTAMP, 9, 4)
    ,('Comment 10', CURRENT_TIMESTAMP, 5, 2);


INSERT INTO community_data.votes (vote_type, user_id, thread_id, comment_id) VALUES
    ('upvote', 1, 1, 1)
    ,('downvote', 2, 1, NULL)
    ,('upvote', 3, 2, 2)
    ,('downvote', 4, 2, NULL)
    ,('upvote', 5, 3, NULL)
    ,('downvote', 1, 3, NULL)
    ,('upvote', 2, 4, NULL)
    ,('downvote', 3, 4, NULL)
    ,('upvote', 4, 5, NULL)
    ,('downvote', 5, 5, NULL);


INSERT INTO community_data.user_profiles (user_id, bio, avatar_id, gaming_platform_link) VALUES
    (1, 'I love gaming!', MD5(random()::text), 'https://example.com/platform1')
    ,(2, 'Gamer for life!', MD5(random()::text), 'https://example.com/platform2')
    ,(3, 'Gaming is my passion', MD5(random()::text), 'https://example.com/platform3')
    ,(4, 'Professional gamer', MD5(random()::text), 'https://example.com/platform4')
    ,(5, 'Gaming enthusiast', MD5(random()::text), 'https://example.com/platform5')
    ,(6, 'Casual gamer', MD5(random()::text), 'https://example.com/platform6')
    ,(7, 'Competitive gamer', MD5(random()::text), 'https://example.com/platform7')
    ,(8, 'Gamer geek', MD5(random()::text), 'https://example.com/platform8')
    ,(9, 'Gaming addict', MD5(random()::text), 'https://example.com/platform9')
    ,(10, 'Gaming for fun', MD5(random()::text), 'https://example.com/platform10');


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


INSERT INTO community_data.game_reviews (game_id, user_id, score, review_text) VALUES
    (1, 1, 5, 'Absolutely loved this game, one of the best RPGs ever!')
    ,(2, 2, 4, 'A fantastic open-world game with breathtaking visuals.')
    ,(3, 3, 5, 'GTA V offers an immersive experience with its diverse gameplay.')
    ,(4, 4, 5, 'An epic Western adventure with an engrossing story.')
    ,(5, 5, 5, 'The remake captures the essence of the original while adding new elements.')
    ,(6, 6, 4, 'A masterpiece in storytelling, but the gameplay could be improved.')
    ,(7, 7, 5, 'A charming and relaxing game, perfect for unwinding.')
    ,(8, 8, 3, 'Fortnite is fun, but the constant updates can be overwhelming.')
    ,(9, 9, 5, 'Minecraft offers endless creativity and exploration.')
    ,(10, 10, 4, 'Warzone delivers intense multiplayer action, but suffers from cheaters.');


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
