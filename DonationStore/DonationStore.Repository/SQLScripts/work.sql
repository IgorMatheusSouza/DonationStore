
select * from sys.tables
select * from aspnetusers
select * from AspNetUserRoles

select * from DonationImages
AspNetUserClaims
AspNetUserLogins
AspNetUserTokens
AspNetRoleClaims
AspNetUserRoles

select * from Donations d join DonationImages on d.id = donationId

-- update donations set description ='O Discman foi o primeiro portátil leitor de CDs, mídias que durante algum tempo foram top de linha quando o assunto era qualidade digital de áudio.' where id = 'E9D0252B-209A-451F-581B-08D9AE968929'

-- delete from Donations 
-- delete aspnetusers where email = 'pkdesouza@gmail.com'


