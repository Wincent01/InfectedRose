# InfectedRose.Interface
A interface for interacting with the many libraries of InfectedRose. This is done through xml files which can be used to specify new npcs, missions, and zones.

## Setup
* Run the interface through `dotnet ./InfectedRose.Interface.dll`, this will generate the `config.xml` file.
* In this file you need to specify the `res` directory of your unpacked LEGO Universe client.
* The `cdclient.fdb` should be copied to same folder as this interface. Version control for modifications is not implemented yet, so the interface has to start from a new database each time.
* Create your xml files, see Examples.
* Run the interface again, this will modify the client files and its database.
* A SQL file will be generated which you should run on your server's CDClient.

## Examples
###### config.xml
```xml
<Config>
  <CDClient>cdclient.fdb</CDClient>
  <Output>/mnt/disk/LEGO Universe/res</Output>
  <SqlOutput>output.sql</SqlOutput>
  <Release>false</Release>
  <Npc>npc.xml</Npc>
  <Mission>mission.xml</Mission>
  <Zone>zone.xml</Zone>
</Config>
```
###### npc.xml
```xml
<Npc>
  <Lot>20000</Lot>
  <Name>my npc</Name>
  <InteractDistance>5</InteractDistance>
  <Style>
    <Chest>14</Chest>
    <ChestDecal>38</ChestDecal>
    <EyeBrowStyle>33</EyeBrowStyle>
    <EyesStyle>10</EyesStyle>
    <HairColor>2</HairColor>
    <HairStyle>6</HairStyle>
    <Head>0</Head>
    <HeadColor>0</HeadColor>
    <LeftHand>0</LeftHand>
    <Legs>5</Legs>
    <MouthStyle>11</MouthStyle>
    <RightHand>0</RightHand>
  </Style>
  <Item>6938</Item>
  <Mission>
  	<MissionId>30000</MissionId>
  	<Offers>true</Offers>
  	<Accepting>true</Accepting>
  </Mission>
</Npc>
```
###### mission.xml
```xml
<Mission>
  <Id>30000</Id>
  <Type>Location</Type>
  <SubType>Venture Explorer</SubType>
  <UiSortOrder>0</UiSortOrder>
  <RewardCurrency>666</RewardCurrency>
  <RewardScore>10</RewardScore>
  <IsMission>true</IsMission>
  <ChoiceRewards>false</ChoiceRewards>
  <EmoteRewards>-1</EmoteRewards>
  <EmoteRewards>-1</EmoteRewards>
  <EmoteRewards>-1</EmoteRewards>
  <EmoteRewards>-1</EmoteRewards>
  <RewardMaxImagination>0</RewardMaxImagination>
  <RewardMaxHealth>4</RewardMaxHealth>
  <RewardMaxInventory>4</RewardMaxInventory>
  <Repeatable>false</Repeatable>
  <RepeatRewardCurrency>0</RepeatRewardCurrency>
  <MissionIconId>0</MissionIconId>
  <OfferObject>20000</OfferObject>
  <TargetObject>20000</TargetObject>
  <InMotd>false</InMotd>
  <ItemReward>
    <Lot>2620</Lot>
    <Count>42</Count>
  </ItemReward>
  <ItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </ItemReward>
  <ItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </ItemReward>
  <ItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </ItemReward>
  <RepeatItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </RepeatItemReward>
  <RepeatItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </RepeatItemReward>
  <RepeatItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </RepeatItemReward>
  <RepeatItemReward>
    <Lot>-1</Lot>
    <Count>0</Count>
  </RepeatItemReward>
  <EmoteReward>-1</EmoteReward>
  <EmoteReward>-1</EmoteReward>
  <EmoteReward>-1</EmoteReward>
  <EmoteReward>-1</EmoteReward>
  <Task>
    <TaskType>0</TaskType>
    <Target>4712</Target>
    <TargetGroup>6351,8088,8089,9744</TargetGroup>
    <TargetValue>3</TargetValue>
    <Parameters>
    </Parameters>
    <IconId>2908</IconId>
    <LargeIcon>..\..\textures\ui\missioncomics\Wonderland\Avant_Gardens\Task_Icons\Battle_Maelstrom_Task.dds</LargeIcon>
    <LargeIconId>2908</LargeIconId>
  </Task>
</Mission>
```
###### zone.xml
Note: creating new zones is still work in progress. Terrain files can be created via code using InfectedRose.Terrain.
```xml
<Zone>
  <Name>my_maps/zone/zone.luz</Name>
  <Id>60000</Id>
  <Revision>1</Revision>
  <GhostDistance>500</GhostDistance>
  <Description>amazing zone</Description>
  <Scene Name="Global Scene" Id="0" Layer="0" Revision="1">
    <SkyBox>mesh\env\NG_NinjaGo\env_nj_mon_sky.nif</SkyBox>
    <Object Lot="31" AssetType="1">
      <Position>
        <X>0</X>
        <Y>30</Y>
        <Z>0</Z>
      </Position>
      <Rotation>
        <X>0</X>
        <Y>0</Y>
        <Z>0</Z>
        <W>1</W>
      </Rotation>
      <Scale>1</Scale>
      <Info />
    </Object>
  </Scene>
  <SpawnPosition>
    <X>0</X>
    <Y>0</Y>
    <Z>0</Z>
  </SpawnPosition>
  <SpawnRotation>
    <X>0</X>
    <Y>0</Y>
    <Z>0</Z>
    <W>1</W>
  </SpawnRotation>
  <Terrain>
    <FileName>terrain.raw</FileName>
    <Name>terrain</Name>
    <Description>terrain file</Description>
  </Terrain>
</Zone>
```