
create database personal;
use personal;

create table Contact (
	contactId int identity primary key,
	name varchar(50),
	phone varchar(50),
	email varchar(50)
);

/* sp_contact_getcontacts */
create procedure sp_contact_getcontacts
as
begin
	select * from Contact;
end

/* sp_contact_getcontact */
create procedure sp_contact_getcontact (
	@contactId int
)
as
begin
	select * from Contact
	where contactId = @contactId;
end

/* sp_contact_addcontact */
create procedure sp_contact_addcontact (
	@name varchar(50),
	@phone varchar(50),
	@email varchar(50)
)
as
begin
	insert into Contact (name, phone, email) values (@name, @phone, @email)
end

/* sp_contact_updatecontact */
create procedure sp_contact_updatecontact (
	@contactId int,
	@name varchar(50),
	@phone varchar(50),
	@email varchar(50)
)
as
begin
	update Contact set name = @name, phone = @phone, email = @email
	where contactId = @contactId;
end

/* sp_contact_deletecontact */
create procedure sp_contact_deletecontact (
	@contactId int
)
as
begin
	delete from Contact
	where contactId = @contactId;
end


