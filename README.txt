(http://eple.thruhere.net/~gaute/git/gameoflife.git/)
cgit brukar og passord:
gol:gool

sett opp git:
hent:
  - msysgit
  - tortoisegit

lag putty public/privatekey -> send openssh public key på email til meg
(http://linux-sxs.org/networking/openssh.putty.html)

sett opp remote git+ssh://brukar@eple.thruhere.net/home/gaute/repo/gameoflife.git

jobb:
git sync -> pull frå master 
branch -> (slett / checkout / rebase)
jobb - commit
jobb - commit
checkout next
pull (om nye -> checkout branch / rebase)
checkout master 
merge
push origin master:master

eigen/public branch:
første gang: git checkout -b branchname origin/branchname
             git fetch origin branchname:branchname

git pull origin branch:branch
merge til branch
git push origin branch:branch

pull:
git pull origin branch

eg:
merge master -> next

branchar:
master = for vanlig koding
next = det som er klart for neste milepæl

