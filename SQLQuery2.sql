

use ChatUmeDTB
Create table UserAccount
(
	idUser Integer identity(0,1)  NOT NULL, UNIQUE (idUser),
	phoneNumber Varchar(10) NOT NULL UNIQUE,
	password Varchar(16) NULL,
	createOn Datetime NULL,
	updateOn Datetime NULL,
	isActive Bit Default 1 NULL,
	isOnline bit default 0 null,
	sex Bit NULL default 1,
	birthDay date NULL,
	email varchar(max) NULL,
	urlAvarta Varchar(max) NULL,
	userName nvarchar(200),
	Primary Key (idUser),
	code int default 131001
) 
 

create table Friends
(
	idUser Integer NOT NULL,
	idFriend int not null,
	addDay datetime default getdate() null,
	nickName Nvarchar(200) ,
	isActive bit default 1,
	Primary Key (idUser,idFriend)
)


Create table GroupChat
(
	idUser int not null,
	idGroup varchar(50)  NOT NULL,
	numberMember Integer NULL,
	groupName Nvarchar(max),
	avartaGroup Varchar(200) NULL,
	lastMessage Nvarchar(max),
	Primary Key (idGroup)
) ;

Create table InfoGroup
(
	idUser Integer NOT NULL,
	idGroup varchar(50) NOT NULL,
	Primary Key (idUser,idGroup),
);

Create table groupChatMessage
(
	idMess varchar(50)  Primary Key NOT NULL,
	idUser Integer NOT NULL,
	idGroup varchar(50) NOT NULL,
	createOn Datetime default getdate() NULL,
	content Nvarchar (MAX) NOT NULL,

);

Create table Poster
(
	idPoster Integer  identity(0,1)  NOT NULL,
	imgPoster Varchar(max) NULL,
	content Nvarchar(max) NULL,
	createOn Datetime  default getdate() NOT NULL,
    likeNumber int default 0,
	commentNumber int default 0,
    idUser int not null,
	Primary Key (idPoster)
);

Create table Liked
(
	isLike bit default 0,
	idPoster Integer ,
	idUser Integer NOT NULL,
	dateAction Datetime  default getdate() NOT NULL,
	Primary Key (idPoster,idUser),

)
Create table Comment
(
	idComment Integer  identity(0,1)  NOT NULL,
	createOn Datetime  default getdate() NOT NULL,
	content Nvarchar(2000) not NULL,
	idUser Integer NOT NULL,
	idPoster Integer NOT NULL,
	Primary Key (idComment),
);
-- thêm 1 người dùng
insert into UserAccount (phoneNumber,password,userName) values ('0866039125','123',N'nhất')
insert into UserAccount (phoneNumber,password,userName) values ('0866038126','123',N'long')
insert into UserAccount (phoneNumber,password,userName) values ('0866038127','123',N'bin')
select * from UserAccount

use ChatUmeDTB
select * from UserAccount
insert into friends(idUser,idFriend) values (3,1)

-- tạo group chát
insert into GroupChat (idUser,idGroup) values (0,'nn1')
insert into GroupChat (idUser,idGroup) values (1,'nn1b')


-- insert người dùng vào group chat
insert into  InfoGroup (idUser,idGroup) values (0,'nn1')
insert into  InfoGroup (idUser,idGroup) values (1,'nn1b')
insert into  InfoGroup (idUser,idGroup) values (2,'nn1b')
insert into  InfoGroup (idUser,idGroup) values (2,'nn1')


-- insert tin nhắn
insert into groupChatMessage (idUser, content, idGroup,idMess) values (0,N'hế lo cả nhà', 'nn1','b1')
insert into groupChatMessage (idUser, content, idGroup,idMess) values (1,N'helo 2', 'nn1b','b2')
insert into groupChatMessage (idUser, content, idGroup,idMess) values (0,N'2 cc', 'nn1','b3')
insert into groupChatMessage (idUser, content, idGroup,idMess) values (2,N'2 noooo', 'nn1','b4')


select g.* from InfoGroup i, UserAccount u , GroupChat g
where u.idUser= I.idUser and u.idUser= 2 and g.idGroup= i.idGroup

-- load tin nhắn trong group chat
select m.*, u.urlAvarta  from UserAccount u, groupChatMessage m
where m.idUser= u.idUser and m.idGroup='nn1' and m.idUser=2

-- đếm số lượng thành viên group chát
select COUNT(i.idUser) from GroupChat g, InfoGroup i 
where i.idGroup= g.idGroup and g.idGroup='nn1b'


-- truy vấn tìm tin nhắn qua id và qua group chát
select m.*, u.urlAvarta from groupChatMessage m, InfoGroup s , UserAccount u
where u.idUser= m.idUser and s.idUser =2 and s.idGroup= m.idGroup and s.idGroup=0

-- update số lượng thành viên trong group chat
update GroupChat
set numberMember = (select COUNT(i.idUser) from GroupChat g, InfoGroup i 
where i.idGroup= g.idGroup and g.idGroup='nn1b')
where  idGroup='nn1b' 

update GroupChat set lastMessage= N'null nha' where idGroup= 'nn1b'
select * from groupChatMessage

select m.* from groupChatMessage m,
InfoGroup i where i.idGroup= m.idGroup and m.idGroup='nn1' and m.idUser= i.idUser

-- xuat all group chat


----------------------------------------------------------------------------------------------------------------------------
use chatumedtb
-- đăng poster
insert into Poster(content,idUser) values (N'hihi',0)
insert into Poster(content,idUser) values (N'hihi no',2)

-- like Poser
insert into Liked(idUser,idPoster) values (1,0)

--cooment poster
insert into Comment(idUser,idPoster,content) values (1,0,N'nice')
insert into Comment(idUser,idPoster,content) values (0,0,N'thanks')

-- cập nhật số lượng like
update Poster 
set likeNumber= (select COUNT(idUser) from Liked  where idPoster =0)
where idPoster=0

-- cập nhật số lượng comment
update Poster 
set commentNumber= (select COUNT(idUser) from Comment  where idPoster =0)
where idPoster=0



select u.* from UserAccount u, GroupChat g , InfoGroup i where