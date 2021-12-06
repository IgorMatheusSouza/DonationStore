
select * from sys.tables
select * from aspnetusers
select * from DonationsAcquisition

select * from DonationImages
AspNetUserClaims
AspNetUserLogins
AspNetUserTokens
AspNetRoleClaims
AspNetUserRoles

select * from Donations d join DonationImages on d.id = donationId join aspnetusers a on d.UserId = a.Id

update aspnetusers set PhoneNumber =  '21991346450' where id = 'de50f0ed-e1fd-4b81-a9cb-c62cb684dbb4'

-- update donations set description ='O Discman foi o primeiro portátil leitor de CDs, mídias que durante algum tempo foram top de linha quando o assunto era qualidade digital de áudio.' where id = 'E9D0252B-209A-451F-581B-08D9AE968929'

--delete from DonationImages where id = '41288F85-592A-4149-9272-08D9B21EA934'
-- delete aspnetusers where email = 'pkdesouza@gmail.com'


select * from DonationAcquisition ad join aspnetusers a on a.Id = ad.userId