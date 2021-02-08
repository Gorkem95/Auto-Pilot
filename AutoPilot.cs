{$CLEO}
0000:
0@ = 0
$_P = 0
$_G = 0
$_R = 0
$_B = 0

while true
wait 0
if and  
key_down 80
8B21: 	samp is_chat_opened
then
 if $_P == 0
 then $_P = 1
 0@ = 1
 0AF8: samp add_message_to_chat "[AUTO-PILOT]: Auto Pilot Enabled" color 0x7CFC00
 else $_P = 0
 0@ = 0
 0AF8: samp add_message_to_chat "[AUTO-PILOT]: Auto Pilot Disabled" color 0xFF0000
 $_G = 0
 $_B = 0
 if Actor.Driving($PLAYER_ACTOR)
 then 1@ = Actor.CurrentCar($PLAYER_ACTOR)
 0362: $PLAYER_ACTOR 2@ 3@ 4@
 036A: $PLAYER_ACTOR 1@
 end
 end
 wait 1000
end
if and
 key_down 82
 8B21: 	samp is_chat_opened
then
 if $_R == 0
 then $_R = 1
 0AF8: samp add_message_to_chat "[AUTO-PILOT]: Play Back Enabled" color 0x7CFC00
 else $_R = 0
 0AF8: samp add_message_to_chat "[AUTO-PILOT]: Play Back Disabled" color 0xFF0000
 $_B = 0
 end
 wait 1000
end 
if and
Actor.Driving($PLAYER_ACTOR)
$_P == 1
0AB6: 5@ 6@ 7@
$_G == 0 
then
 if or
 04AB: $PLAYER_ACTOR 
 04A9: $PLAYER_ACTOR
 then
 1@ = Actor.CurrentCar($PLAYER_ACTOR)
 00AA: 1@ 2@ 3@ 4@
 if 04AB: $PLAYER_ACTOR 
 then 04D2: 1@ 5@ 6@ 4@ 0.0 0.5
 08E6: 1@ 1
 $_G = 1
 else 0743: 1@ 5@ 6@ 4@ 4@ 4@
 $_G = 1
 end
 0@ = 1
 wait 1000
 end
end
if and
   Actor.Driving($PLAYER_ACTOR)
   0@ == 1
then
 if or
 04AB: $PLAYER_ACTOR
 04A9: $PLAYER_ACTOR
 then
 1@ = Actor.CurrentCar($PLAYER_ACTOR)
 00AA: 1@ 8@ 9@ 10@
  if $_B == 0
  then 0509: 11@ = 5@ 6@ 8@ 9@ 
  else 0509: 11@ = 8@ 9@ 2@ 3@
  end
 0AD3: 12@v = format "Distance: %f" 11@
 0ACD: 12@v time 1
 if 11@ <= 15.0
 then 
 0ACD: "Destination Reached" 1000
  if $_R == 1
  then
   if $_B == 0
   then $_B = 1
   else $_B = 0
   $_G = 0
   end
   if 04AB: $PLAYER_ACTOR 
   then 04D2: 1@ 2@ 3@ 4@ 0.0 0.5
   08E6: 1@ 1
   else 04A2: 1@ 2@ 3@ 4@ 4@ 4@
   end
   else
   0362: $PLAYER_ACTOR 8@ 9@ 10@
   036A: $PLAYER_ACTOR 1@
   0@ = 0
   $_G = 0
   $_P = 0
   $_B = 0
   0AF8: samp add_message_to_chat "[AUTO-PILOT]: Auto Pilot Disabled" color 0xFF0000
   continue
  end 
 end
 end
 end
 END
