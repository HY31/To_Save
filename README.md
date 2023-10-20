## To Save - A04조 심화 프로젝트
#### 어머니를 구하기 위해 위험한 산에 가는 슬라임의 이야기

어느 날 원인 불명의 병으로 앓아 누운 어머니 슬라임

세계 최고의 의사도 손을 쓰지 못했으나 딱 하나의 방법이 남아있었는데...

### 구현 기능
##### 이형빈
- UI/UX 요소 : 일시 정지 및 사운드 조절 창
- 사운드 및 음악효과 추가

##### 조성훈
- 충돌 처리 및 피해량 계산 : 사망 기능과 장애물의 연동
- 여러 장애물 구현
  - 올라갔을 때 2초간 깜빡이다 사라지는 발판(구름)
  - 상하좌우로 움직이는 발판
  - 밟으면 가시가 올라왔다가 다시 들어가는 발판(스파이크 트랩)
  - 계속 회전하는 장애물(a.k.a 맛동산)
  - 5초 간격으로 계속 발사하는 대포(캐논)

##### 김호연
- 스테이트 머신으로 만든 플레이어 조작(공격, 이동, 점프 등)
- 시네머신을 이용한 인트로 컷씬
- 스토리 기획

##### 곽민규
- 체크 포인트 시스템
- 게임 엔딩과 크레딧 제작
- 사망 시 재시작 기능 구현

##### 김진규
- 맵 구성 : 2D 타일맵을 이용하여 gameobject brush로 3D 맵을 구성하였습니다.
- MainStageScene : 처음 게임이 시작하면 플레이어가 움직이는 공간입니다. 이곳에서 다음 스테이지로 넘어갈 수 있습니다.
- StageScene1 : 바닥에 떨어지면 죽는 점프맵입니다. 두 갈래 길이 있으며 끝에는 다시 MainStageScene으로 넘어가는 포탈이있습니다
- StageScene2: 아래에서 위로 올라가는 점프맵입니다. 대각선으로 굴러오는 포탄이나 구름 발판을 밟고 올라가면 다시 MainStageScene으로 넘어가는 포탈이있습니다.
- EndPoint : EndPoint와 충돌하면 게임이 끝납니다.
- Portal :  다른 스테이지씬으로 넘어가는 포탈입니다. 플레이이가 충돌하면 플레이어를 디스트로이 하고 스폰메니저에 저장 된 스폰 포인트로 플레이어를 재생성합니다.
- SpawnManager : 플레이어가 스폰하는 것을 관리하는 스크립트입니다. 플레이어가 스폰 될 트랜스폼 정보를 리스트로 가지고 있습니다. 씬이 로드되면 virtual camera의 follow와 lookat에 cameraLookPoint를 지정합니다.

