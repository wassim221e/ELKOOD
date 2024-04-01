Explanation of the entry




Company




api/Company/all
enter : State [active ,inactive ,null] null return all company active and inactive




Branch



update Main Branch 
api/Branch/MainBranch 
 if [BranchType] is Secondary This means converting the Main Branch to a Secondary Branch Then you must enter [MainBranchName]


GetAllMainBranch 
api/Branch/MainBranch/all :CompanyName [string(The Name of Company) ,null] null return all Main Branch For all companies


Update Secondary Branch 
api/Branch/SecondaryBranch
if [BranchType] is Main This means converting the Secondary Branch to a Main Branch 


Get All Secondary Branches 
api/Branch/SecondaryBranch/all : MainBranchName [string(The Name Of Main Branch),null] null return all Secondary Branches For All Main Branch 


Get All Distribution operations 
api/Branch/Distribution/all : MainBranchId [string (The Id of Main Branch), null] null return all Distriubtion operations for all Main Branch   