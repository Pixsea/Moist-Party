//Maya ASCII 2019 scene
//Name: viewingBox.ma
//Last modified: Sun, Mar 06, 2022 12:54:26 PM
//Codeset: 1252
requires maya "2019";
requires "mtoa" "3.1.2";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2019";
fileInfo "version" "2019";
fileInfo "cutIdentifier" "201812112215-434d8d9c04";
fileInfo "osv" "Microsoft Windows 10 Technical Preview  (Build 19042)\n";
createNode transform -s -n "persp";
	rename -uid "4D416DAD-4D3C-AB7F-880E-3797488A490D";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 16.143169520814237 2.7052973067425765 1.5096214838015243 ;
	setAttr ".r" -type "double3" -5.7383527295548404 78.999999999982322 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "1FBF62A1-4A75-14B7-7CAF-DFAFEBB3F8EE";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 15.505484036846221;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 0 1.7533777606983489 0 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "EA7478B0-48F7-72A0-3BF6-B381C77B9B25";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "E343BF17-4AB1-D575-38AA-BDA63A85251D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "613B9984-457A-AB88-B784-DDBAC17AF8BC";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "BB8C14B8-42B2-39B2-569C-FB873466B44D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "1B00A221-4E2D-3F5F-0F82-C990B639BF36";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "345C1905-416B-21DE-E26C-E6A63262B9D2";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "pCube1";
	rename -uid "581ECF17-4DB7-A701-F1D6-309C6F0F4692";
	setAttr ".s" -type "double3" 4.3875208473110288 0.50908529634884336 4.560434294220058 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "8FB08B62-44FB-83A2-A350-13AA961F4862";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50921288132667542 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 10 ".pt";
	setAttr ".pt[33]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[34]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[36]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[38]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[40]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[42]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[43]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[44]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[45]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".pt[46]" -type "float3" 0 -0.21081813 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "79033F4A-4C4F-39B5-7150-ECBD799740AF";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "E4853950-41A6-2FC2-3299-22BC7070E305";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "68F672F5-4EF7-22B9-45D8-D1BAB136FADB";
createNode displayLayerManager -n "layerManager";
	rename -uid "DA0CB6C5-4D05-5573-5956-A995B657ED50";
createNode displayLayer -n "defaultLayer";
	rename -uid "9A8F6CF5-40CE-B5DA-5018-F7B94E135237";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "E85F22BE-4807-949B-F817-4F973DD38546";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "46EDF039-420F-A3E2-D495-C8BE064162AF";
	setAttr ".g" yes;
createNode polyCube -n "polyCube1";
	rename -uid "00640BA3-4410-DAED-4393-B0B66C6A9B46";
	setAttr ".cuv" 4;
createNode polySplitRing -n "polySplitRing1";
	rename -uid "79F84741-4534-D91B-8511-21BA22D13327";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[6:7]" "e[10:11]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".wt" 0.080163381993770599;
	setAttr ".re" 7;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing2";
	rename -uid "4DCFC0D6-45D4-DA19-8295-2AA1A2EAEA62";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[10:13]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".wt" 0.90727132558822632;
	setAttr ".dr" no;
	setAttr ".re" 12;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "17C9E247-4DD1-EFF0-E780-66A34201456C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[0:3]" "e[14]" "e[18]" "e[22]" "e[26]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".wt" 0.92928940057754517;
	setAttr ".dr" no;
	setAttr ".re" 1;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polySplitRing -n "polySplitRing4";
	rename -uid "315F78D5-432A-B105-0689-63849B399961";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[0:3]" "e[18]" "e[26]" "e[29]" "e[31]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".wt" 0.07931121438741684;
	setAttr ".re" 1;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "09C9707F-4333-5E8E-DE45-5A943C5DE893";
	setAttr ".ics" -type "componentList" 6 "f[1]" "f[6]" "f[10]" "f[14:16]" "f[22]" "f[24]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 0.25454265 0 ;
	setAttr ".rs" 62120;
	setAttr ".lt" -type "double3" 0 0 0.90683126717271434 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.1937604236555144 0.25454264817442168 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" 2.1937604236555144 0.25454264817442168 2.280217147110029 ;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "A346E084-408C-1DC5-BC29-C1842B0AFFBC";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[6]" "f[10]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -2.0320735 1.1613739 0 ;
	setAttr ".rs" 54493;
	setAttr ".lt" -type "double3" -1.3322676295501878e-15 0 2.599923332724714 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.1937604236555144 1.1613738936204683 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" -1.8703867525787874 1.1613738936204683 2.280217147110029 ;
createNode polySplitRing -n "polySplitRing5";
	rename -uid "DD3933C2-4849-2744-472B-D0A874D6A147";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[90:91]" "e[93]" "e[95]" "e[98]" "e[100]" "e[103]" "e[105]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".wt" 0.90263563394546509;
	setAttr ".dr" no;
	setAttr ".re" 91;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "BCC646B0-49A8-5386-5E63-C8ACEE4EF1AB";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -1.8703867 3.6347275 0 ;
	setAttr ".rs" 39566;
	setAttr ".lt" -type "double3" -4.4408920985006262e-16 -9.5387838675764592e-17 2.8473627777174406 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.8703867525787874 3.508157649936599 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" -1.8703867525787874 3.7612974413187614 2.280217147110029 ;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "1025788A-48C9-C484-ECE9-7E9B437BF4F2";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.97697616 3.6347277 0 ;
	setAttr ".rs" 57188;
	setAttr ".lt" -type "double3" 4.4408920985006262e-16 -7.5760504833287363e-16 0.23773430161035783 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.97697601767252351 3.5081578926873846 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" 0.97697627918914498 3.7612976840695471 2.280217147110029 ;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "0AA0B928-43F5-7512-434E-9BB7702D9722";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.2147104 3.5932028 0 ;
	setAttr ".rs" 53409;
	setAttr ".lt" -type "double3" -0.1078313489831971 1.01675124482975e-15 0.23296831269104745 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.1857755956161093 3.4699846033374739 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" 1.2436451704571794 3.7164210745151984 2.280217147110029 ;
createNode polyTweak -n "polyTweak1";
	rename -uid "516329F4-4720-4DA6-9BDE-209B5C03C181";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[72:79]" -type "float3"  -0.0065947575 -0.07498467
		 3.3306691e-15 -0.0065947562 -0.07498461 3.3306691e-15 0.0065947543 -0.088152185 3.3306691e-15
		 0.0065947548 -0.088152125 3.3306691e-15 -0.0065947543 -0.074984491 -3.3306691e-15
		 0.0065947575 -0.088152006 -3.3306691e-15 -0.0065947543 -0.074984491 -3.3306691e-15
		 0.0065947575 -0.088152006 -3.3306691e-15;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "DD5F19B2-4D44-3E2E-E945-AFBD03A18B72";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.4168587 3.4349692 2.038673e-07 ;
	setAttr ".rs" 60395;
	setAttr ".lt" -type "double3" -0.24380689817457957 0 0.31293525807964345 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.38792402132385 3.3117509019983031 -2.28021673937543 ;
	setAttr ".cbx" -type "double3" 1.4457933346482983 3.5581876159268138 2.280217147110029 ;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "215674EB-4F9B-B006-8691-FA8AA59DB4E0";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.6657715 3.12608 2.038673e-07 ;
	setAttr ".rs" 49665;
	setAttr ".lt" -type "double3" -0.24528711182957044 1.1702641080583304e-15 0.25986205547385499 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.6368368492969101 3.0028616933571213 -2.28021673937543 ;
	setAttr ".cbx" -type "double3" 1.6947061626213586 3.2492984072856324 2.280217147110029 ;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "50945B6D-4459-129F-0651-039F01ADD0DA";
	setAttr ".ics" -type "componentList" 1 "f[59:61]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.8626784 2.8278825 0 ;
	setAttr ".rs" 59079;
	setAttr ".lt" -type "double3" -0.0084404290969602586 1.8204927939753399e-15 0.19921936101119506 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.7832223473084654 2.7797576994767801 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" 1.9421344914921983 2.8760071723694622 2.280217147110029 ;
createNode polyTweak -n "polyTweak2";
	rename -uid "DADA45B9-4629-F8D9-2CAA-3CA6B8BE662B";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[96:103]" -type "float3"  -0.011514773 0.14750642 9.9920072e-15
		 -0.011514798 0.14750662 9.9920072e-15 0.011514817 -0.147507 9.9920072e-15 0.011514817
		 -0.147507 9.9920072e-15 -0.011514817 0.147507 -9.9920072e-15 0.011514798 -0.14750662
		 -9.9920072e-15 -0.011514817 0.147507 -9.9920072e-15 0.011514798 -0.14750662 -9.9920072e-15;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "9312A86E-4479-3093-F2B8-57A51FA796E5";
	setAttr ".ics" -type "componentList" 2 "f[14]" "f[16]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 2.0386384 1.1613739 0 ;
	setAttr ".rs" 34530;
	setAttr ".lt" -type "double3" 4.4408920985006262e-16 0 1.396511618135386 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.8835161945636345 1.1613738936204683 -2.280217147110029 ;
	setAttr ".cbx" -type "double3" 2.1937604236555144 1.1613738936204683 2.280217147110029 ;
createNode polyTweak -n "polyTweak3";
	rename -uid "4DE529AB-4500-8261-6350-00A5849BBD43";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[104:111]" -type "float3"  -0.0030051616 0.107976 8.8817842e-15
		 -0.00300515 0.10797609 8.8817842e-15 0.0030051549 -0.10797608 -2.9094949e-11 0.0030051451
		 -0.10797646 2.9112712e-11 -0.0030051456 0.10797646 2.9094949e-11 0.0030051572 -0.10797609
		 -8.8817842e-15 -0.0030051444 0.10797642 -1.4560797e-11 0.0030051616 -0.107976 -2.3283953e-10;
createNode polyTweak -n "polyTweak4";
	rename -uid "E02ED82F-4511-AF0D-2FDA-7B8AB0E4799F";
	setAttr ".uopa" yes;
	setAttr -s 18 ".tk";
	setAttr ".tk[40]" -type "float3" 1.8626451e-09 0 0 ;
	setAttr ".tk[41]" -type "float3" 0 -3.7252903e-09 0 ;
	setAttr ".tk[104]" -type "float3" -0.016770879 -0.045394063 7.4505806e-09 ;
	setAttr ".tk[105]" -type "float3" -0.016770896 -0.045394085 7.7715612e-16 ;
	setAttr ".tk[106]" -type "float3" 0.0054693799 -0.01182086 7.4505806e-09 ;
	setAttr ".tk[107]" -type "float3" 0.0054694219 -0.011820816 7.7715612e-16 ;
	setAttr ".tk[108]" -type "float3" -0.016770927 -0.045394138 3.7252903e-09 ;
	setAttr ".tk[109]" -type "float3" 0.0054693799 -0.01182086 3.7252903e-09 ;
	setAttr ".tk[110]" -type "float3" -0.016770927 -0.045394138 -7.4505806e-09 ;
	setAttr ".tk[111]" -type "float3" 0.0054693799 -0.01182086 -7.4505806e-09 ;
	setAttr ".tk[112]" -type "float3" -0.025870671 -0.44914868 0 ;
	setAttr ".tk[113]" -type "float3" -0.025870671 -0.44914868 0 ;
	setAttr ".tk[114]" -type "float3" -0.025870671 -0.44914868 0 ;
	setAttr ".tk[115]" -type "float3" -0.025870671 -0.44914868 0 ;
	setAttr ".tk[116]" -type "float3" -0.024378955 -0.41097856 0.0067461273 ;
	setAttr ".tk[117]" -type "float3" -0.024378955 -0.41097856 0.0067461273 ;
	setAttr ".tk[118]" -type "float3" -0.024378955 -0.41097856 0.0067461273 ;
	setAttr ".tk[119]" -type "float3" -0.024378955 -0.41097856 0.0067461273 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "7F2D49AD-45B1-7496-944E-719BE7C3A6BC";
	setAttr ".dc" -type "componentList" 2 "f[59]" "f[61]";
createNode deleteComponent -n "deleteComponent2";
	rename -uid "7F302B2D-4967-94AC-DF5F-AAA76F5D826D";
	setAttr ".dc" -type "componentList" 2 "f[14]" "f[16]";
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "A33D9868-4767-301A-5C35-F98315A12669";
	setAttr ".ics" -type "componentList" 2 "vtx[111]" "vtx[113]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyTweak -n "polyTweak5";
	rename -uid "936DCDE9-4E5C-95A5-73C2-439CA3777693";
	setAttr ".uopa" yes;
	setAttr -s 10 ".tk";
	setAttr ".tk[112]" -type "float3" 0.0051186727 0.58406413 0 ;
	setAttr ".tk[113]" -type "float3" -0.0011291619 0.58406413 0 ;
	setAttr ".tk[114]" -type "float3" -0.0011291619 0.58406413 0 ;
	setAttr ".tk[115]" -type "float3" 0.0051186727 0.58406413 0 ;
	setAttr ".tk[116]" -type "float3" 0.0015282326 0.55467004 0 ;
	setAttr ".tk[117]" -type "float3" 0.0015282326 0.55467004 0 ;
	setAttr ".tk[118]" -type "float3" -0.0030482432 0.55467004 0 ;
	setAttr ".tk[119]" -type "float3" -0.0030482432 0.55467004 0 ;
createNode polyMergeVert -n "polyMergeVert2";
	rename -uid "E62530EF-4FEE-895F-D6A8-69A03E4C715B";
	setAttr ".ics" -type "componentList" 2 "vtx[109]" "vtx[113]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".d" 0;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert3";
	rename -uid "5C72619E-4611-F35C-82A6-D5B6D0ED0BD2";
	setAttr ".ics" -type "componentList" 2 "vtx[108]" "vtx[113]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert4";
	rename -uid "FDCAEAF2-4934-A3C9-DF8A-4F89B5BBD3CF";
	setAttr ".ics" -type "componentList" 2 "vtx[110]" "vtx[112]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert5";
	rename -uid "122E1FB0-427F-514E-3D09-40992B723F43";
	setAttr ".ics" -type "componentList" 2 "vtx[106]" "vtx[115]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert6";
	rename -uid "FEB90026-4EBA-5C75-431B-6BA84F7A6EB1";
	setAttr ".ics" -type "componentList" 2 "vtx[104]" "vtx[113]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert7";
	rename -uid "28764823-41DD-7C8F-AC50-53AC3F9D534F";
	setAttr ".ics" -type "componentList" 2 "vtx[105]" "vtx[112]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyMergeVert -n "polyMergeVert8";
	rename -uid "4A44C9C4-4AB6-D727-67DA-A48F7D8FABC8";
	setAttr ".ics" -type "componentList" 2 "vtx[107]" "vtx[112]";
	setAttr ".ix" -type "matrix" 4.3875208473110288 0 0 0 0 0.50908529634884336 0 0 0 0 4.560434294220058 0
		 0 0 0 1;
	setAttr ".am" yes;
createNode polyCrease -n "polyCrease1";
	rename -uid "EFDCAFEC-48FB-30EE-E4B2-7ABF683CF289";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 29 "e[0]" "e[3:5]" "e[8:11]" "e[14]" "e[16]" "e[21]" "e[23]" "e[31]" "e[37]" "e[43]" "e[49]" "e[52]" "e[65]" "e[69:70]" "e[72]" "e[77]" "e[79]" "e[83:92]" "e[97]" "e[102:103]" "e[105:107]" "e[109]" "e[115]" "e[122]" "e[125]" "e[133]" "e[135]" "e[220]" "e[223:225]";
	setAttr -s 49 ".cr";
	setAttr ".cr[0]" 1.7899999618530273;
	setAttr ".cr[3]" 1.7899999618530273;
	setAttr ".cr[4]" 1.7899999618530273;
	setAttr ".cr[5]" 1.7899999618530273;
	setAttr ".cr[8]" 1.7899999618530273;
	setAttr ".cr[9]" 1.7899999618530273;
	setAttr ".cr[10]" 1.7899999618530273;
	setAttr ".cr[11]" 1.7899999618530273;
	setAttr ".cr[14]" 1.7899999618530273;
	setAttr ".cr[16]" 1.7899999618530273;
	setAttr ".cr[21]" 1.7899999618530273;
	setAttr ".cr[23]" 1.7899999618530273;
	setAttr ".cr[31]" 1.7899999618530273;
	setAttr ".cr[37]" 1.7899999618530273;
	setAttr ".cr[43]" 1.7899999618530273;
	setAttr ".cr[49]" 1.7899999618530273;
	setAttr ".cr[52]" 1.7899999618530273;
	setAttr ".cr[65]" 1.7899999618530273;
	setAttr ".cr[69]" 1.7899999618530273;
	setAttr ".cr[70]" 1.7899999618530273;
	setAttr ".cr[72]" 1.7899999618530273;
	setAttr ".cr[77]" 1.7899999618530273;
	setAttr ".cr[79]" 1.7899999618530273;
	setAttr ".cr[83]" 1.7899999618530273;
	setAttr ".cr[84]" 1.7899999618530273;
	setAttr ".cr[85]" 1.7899999618530273;
	setAttr ".cr[86]" 1.7899999618530273;
	setAttr ".cr[87]" 1.7899999618530273;
	setAttr ".cr[88]" 1.7899999618530273;
	setAttr ".cr[89]" 1.7899999618530273;
	setAttr ".cr[90]" 1.7899999618530273;
	setAttr ".cr[91]" 1.7899999618530273;
	setAttr ".cr[92]" 1.7899999618530273;
	setAttr ".cr[97]" 1.7899999618530273;
	setAttr ".cr[102]" 1.7899999618530273;
	setAttr ".cr[103]" 1.7899999618530273;
	setAttr ".cr[105]" 1.7899999618530273;
	setAttr ".cr[106]" 1.7899999618530273;
	setAttr ".cr[107]" 1.7899999618530273;
	setAttr ".cr[109]" 1.7899999618530273;
	setAttr ".cr[115]" 1.7899999618530273;
	setAttr ".cr[122]" 1.7899999618530273;
	setAttr ".cr[125]" 1.7899999618530273;
	setAttr ".cr[133]" 1.7899999618530273;
	setAttr ".cr[135]" 1.7899999618530273;
	setAttr ".cr[220]" 1.7899999618530273;
	setAttr ".cr[223]" 1.7899999618530273;
	setAttr ".cr[224]" 1.7899999618530273;
	setAttr ".cr[225]" 1.7899999618530273;
createNode polyTweak -n "polyTweak6";
	rename -uid "525C2773-4037-129D-07E4-37B02AE9D7D3";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[104:111]" -type "float3"  0.010281447 0 0 0.010281447
		 0 0 -0.0034205941 0 0 -0.0034205941 0 0 0.010281447 0 0 -0.0034205941 0 0 0.010281447
		 0 0 -0.0034205941 0 0;
createNode deleteComponent -n "deleteComponent3";
	rename -uid "C46A6529-40B7-3CE4-6360-20A3A1B2DCBE";
	setAttr ".dc" -type "componentList" 1 "e[98]";
createNode deleteComponent -n "deleteComponent4";
	rename -uid "364E7736-418E-2F2B-4F24-6E8CEACE020F";
	setAttr ".dc" -type "componentList" 1 "e[93]";
createNode deleteComponent -n "deleteComponent5";
	rename -uid "E6884EF2-4EF3-D907-3B83-D8AA57741E9F";
	setAttr ".dc" -type "componentList" 1 "e[127]";
createNode deleteComponent -n "deleteComponent6";
	rename -uid "C4B98AED-4C53-E329-DE6F-44AB4830C45D";
	setAttr ".dc" -type "componentList" 1 "e[121]";
createNode polyCrease -n "polyCrease2";
	rename -uid "C10E2673-42E8-0719-D54E-578C6E7F2637";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 30 "e[0:69]" "e[71]" "e[73]" "e[76]" "e[78]" "e[81]" "e[83]" "e[86:120]" "e[122]" "e[124:125]" "e[127:129]" "e[131:132]" "e[134]" "e[145]" "e[150]" "e[161]" "e[166]" "e[177]" "e[182]" "e[193]" "e[198]" "e[200]" "e[202]" "e[204]" "e[207]" "e[209]" "e[211:212]" "e[214:215]" "e[217:218]" "e[222:223]";
	setAttr -s 141 ".cr";
	setAttr ".cr[0]" 2.369999885559082;
	setAttr ".cr[1]" 2.369999885559082;
	setAttr ".cr[2]" 2.369999885559082;
	setAttr ".cr[3]" 2.369999885559082;
	setAttr ".cr[4]" 2.369999885559082;
	setAttr ".cr[5]" 7.2600011825561523;
	setAttr ".cr[6]" 2.369999885559082;
	setAttr ".cr[7]" 7.2600011825561523;
	setAttr ".cr[8]" 2.369999885559082;
	setAttr ".cr[9]" 7.2600011825561523;
	setAttr ".cr[10]" 2.369999885559082;
	setAttr ".cr[11]" 7.2600011825561523;
	setAttr ".cr[12]" 7.2600011825561523;
	setAttr ".cr[13]" 2.369999885559082;
	setAttr ".cr[14]" 2.369999885559082;
	setAttr ".cr[15]" 2.369999885559082;
	setAttr ".cr[16]" 7.2600011825561523;
	setAttr ".cr[17]" 2.369999885559082;
	setAttr ".cr[18]" 7.2600011825561523;
	setAttr ".cr[19]" 7.2600011825561523;
	setAttr ".cr[20]" 2.369999885559082;
	setAttr ".cr[21]" 2.369999885559082;
	setAttr ".cr[22]" 2.369999885559082;
	setAttr ".cr[23]" 7.2600011825561523;
	setAttr ".cr[24]" 2.369999885559082;
	setAttr ".cr[25]" 7.2600011825561523;
	setAttr ".cr[26]" 7.2600011825561523;
	setAttr ".cr[27]" 2.369999885559082;
	setAttr ".cr[28]" 2.369999885559082;
	setAttr ".cr[29]" 7.2600011825561523;
	setAttr ".cr[30]" 7.2600011825561523;
	setAttr ".cr[31]" 7.2600011825561523;
	setAttr ".cr[32]" 7.2600011825561523;
	setAttr ".cr[33]" 7.2600011825561523;
	setAttr ".cr[34]" 7.2600011825561523;
	setAttr ".cr[35]" 7.2600011825561523;
	setAttr ".cr[36]" 7.2600011825561523;
	setAttr ".cr[37]" 7.2600011825561523;
	setAttr ".cr[38]" 7.2600011825561523;
	setAttr ".cr[39]" 7.2600011825561523;
	setAttr ".cr[40]" 2.369999885559082;
	setAttr ".cr[41]" 2.369999885559082;
	setAttr ".cr[42]" 2.369999885559082;
	setAttr ".cr[43]" 2.369999885559082;
	setAttr ".cr[44]" 2.369999885559082;
	setAttr ".cr[45]" 2.369999885559082;
	setAttr ".cr[46]" 2.369999885559082;
	setAttr ".cr[47]" 2.369999885559082;
	setAttr ".cr[48]" 2.369999885559082;
	setAttr ".cr[49]" 2.369999885559082;
	setAttr ".cr[50]" 2.369999885559082;
	setAttr ".cr[51]" 2.369999885559082;
	setAttr ".cr[52]" 2.369999885559082;
	setAttr ".cr[53]" 2.369999885559082;
	setAttr ".cr[54]" 2.369999885559082;
	setAttr ".cr[55]" 2.369999885559082;
	setAttr ".cr[56]" 2.369999885559082;
	setAttr ".cr[57]" 2.369999885559082;
	setAttr ".cr[58]" 2.369999885559082;
	setAttr ".cr[59]" 2.369999885559082;
	setAttr ".cr[60]" 2.369999885559082;
	setAttr ".cr[61]" 2.369999885559082;
	setAttr ".cr[62]" 2.369999885559082;
	setAttr ".cr[63]" 2.369999885559082;
	setAttr ".cr[64]" 2.369999885559082;
	setAttr ".cr[65]" 2.369999885559082;
	setAttr ".cr[66]" 2.369999885559082;
	setAttr ".cr[67]" 2.369999885559082;
	setAttr ".cr[68]" 7.2600011825561523;
	setAttr ".cr[69]" 7.2600011825561523;
	setAttr ".cr[71]" 7.2600011825561523;
	setAttr ".cr[73]" 7.2600011825561523;
	setAttr ".cr[76]" 7.2600011825561523;
	setAttr ".cr[78]" 7.2600011825561523;
	setAttr ".cr[81]" 7.2600011825561523;
	setAttr ".cr[83]" 7.2600011825561523;
	setAttr ".cr[86]" 2.369999885559082;
	setAttr ".cr[87]" 2.369999885559082;
	setAttr ".cr[88]" 2.369999885559082;
	setAttr ".cr[89]" 2.369999885559082;
	setAttr ".cr[90]" 2.369999885559082;
	setAttr ".cr[91]" 2.369999885559082;
	setAttr ".cr[92]" 2.369999885559082;
	setAttr ".cr[93]" 2.369999885559082;
	setAttr ".cr[94]" 2.369999885559082;
	setAttr ".cr[95]" 2.369999885559082;
	setAttr ".cr[96]" 2.369999885559082;
	setAttr ".cr[97]" 2.369999885559082;
	setAttr ".cr[98]" 2.369999885559082;
	setAttr ".cr[99]" 2.369999885559082;
	setAttr ".cr[100]" 2.369999885559082;
	setAttr ".cr[101]" 2.369999885559082;
	setAttr ".cr[102]" 2.369999885559082;
	setAttr ".cr[103]" 2.369999885559082;
	setAttr ".cr[104]" 2.369999885559082;
	setAttr ".cr[105]" 2.369999885559082;
	setAttr ".cr[106]" 2.369999885559082;
	setAttr ".cr[107]" 2.369999885559082;
	setAttr ".cr[108]" 2.369999885559082;
	setAttr ".cr[109]" 2.369999885559082;
	setAttr ".cr[110]" 2.369999885559082;
	setAttr ".cr[111]" 2.369999885559082;
	setAttr ".cr[112]" 2.369999885559082;
	setAttr ".cr[113]" 2.369999885559082;
	setAttr ".cr[114]" 2.369999885559082;
	setAttr ".cr[115]" 2.369999885559082;
	setAttr ".cr[116]" 2.369999885559082;
	setAttr ".cr[117]" 2.369999885559082;
	setAttr ".cr[118]" 2.369999885559082;
	setAttr ".cr[119]" 2.369999885559082;
	setAttr ".cr[120]" 2.369999885559082;
	setAttr ".cr[122]" 2.369999885559082;
	setAttr ".cr[124]" 2.369999885559082;
	setAttr ".cr[125]" 2.75;
	setAttr ".cr[127]" 2.369999885559082;
	setAttr ".cr[128]" 2.75;
	setAttr ".cr[129]" 2.369999885559082;
	setAttr ".cr[131]" 2.369999885559082;
	setAttr ".cr[132]" 2.75;
	setAttr ".cr[134]" 1.8799999952316284;
	setAttr ".cr[145]" 1.8799999952316284;
	setAttr ".cr[150]" 1.8799999952316284;
	setAttr ".cr[161]" 1.8799999952316284;
	setAttr ".cr[166]" 1.8799999952316284;
	setAttr ".cr[177]" 1.8799999952316284;
	setAttr ".cr[182]" 1.8799999952316284;
	setAttr ".cr[193]" 1.8799999952316284;
	setAttr ".cr[198]" 1.8799999952316284;
	setAttr ".cr[200]" 3.0199999809265137;
	setAttr ".cr[202]" 3.0199999809265137;
	setAttr ".cr[204]" 3.0199999809265137;
	setAttr ".cr[207]" 3.0199999809265137;
	setAttr ".cr[209]" 3.0199999809265137;
	setAttr ".cr[211]" 1.8799999952316284;
	setAttr ".cr[212]" 3.0199999809265137;
	setAttr ".cr[214]" 3.0199999809265137;
	setAttr ".cr[215]" 3.130000114440918;
	setAttr ".cr[217]" 3.2799999713897705;
	setAttr ".cr[218]" 3.2799999713897705;
	setAttr ".cr[222]" 3.2799999713897705;
	setAttr ".cr[223]" 3.2799999713897705;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "3E88647F-45A9-1E54-9D9A-35A866244FAC";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n"
		+ "            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n"
		+ "            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1754\n            -height 1064\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n"
		+ "            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n"
		+ "            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"0\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n"
		+ "                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n"
		+ "                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n"
		+ "                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n"
		+ "            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n"
		+ "                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n"
		+ "                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n"
		+ "\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n"
		+ "                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n"
		+ "                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xpm\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1754\\n    -height 1064\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1754\\n    -height 1064\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "C6A45579-44D0-9A30-8564-4B9CEF51D4DC";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polyCrease2.out" "pCubeShape1.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polySplitRing1.ip";
connectAttr "pCubeShape1.wm" "polySplitRing1.mp";
connectAttr "polySplitRing1.out" "polySplitRing2.ip";
connectAttr "pCubeShape1.wm" "polySplitRing2.mp";
connectAttr "polySplitRing2.out" "polySplitRing3.ip";
connectAttr "pCubeShape1.wm" "polySplitRing3.mp";
connectAttr "polySplitRing3.out" "polySplitRing4.ip";
connectAttr "pCubeShape1.wm" "polySplitRing4.mp";
connectAttr "polySplitRing4.out" "polyExtrudeFace1.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace1.mp";
connectAttr "polyExtrudeFace1.out" "polyExtrudeFace2.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace2.out" "polySplitRing5.ip";
connectAttr "pCubeShape1.wm" "polySplitRing5.mp";
connectAttr "polySplitRing5.out" "polyExtrudeFace3.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace3.out" "polyExtrudeFace4.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace4.mp";
connectAttr "polyTweak1.out" "polyExtrudeFace5.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace5.mp";
connectAttr "polyExtrudeFace4.out" "polyTweak1.ip";
connectAttr "polyExtrudeFace5.out" "polyExtrudeFace6.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace6.mp";
connectAttr "polyExtrudeFace6.out" "polyExtrudeFace7.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace7.mp";
connectAttr "polyTweak2.out" "polyExtrudeFace8.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace7.out" "polyTweak2.ip";
connectAttr "polyTweak3.out" "polyExtrudeFace9.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace9.mp";
connectAttr "polyExtrudeFace8.out" "polyTweak3.ip";
connectAttr "polyExtrudeFace9.out" "polyTweak4.ip";
connectAttr "polyTweak4.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "deleteComponent2.ig";
connectAttr "polyTweak5.out" "polyMergeVert1.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert1.mp";
connectAttr "deleteComponent2.og" "polyTweak5.ip";
connectAttr "polyMergeVert1.out" "polyMergeVert2.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert2.mp";
connectAttr "polyMergeVert2.out" "polyMergeVert3.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert3.mp";
connectAttr "polyMergeVert3.out" "polyMergeVert4.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert4.mp";
connectAttr "polyMergeVert4.out" "polyMergeVert5.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert5.mp";
connectAttr "polyMergeVert5.out" "polyMergeVert6.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert6.mp";
connectAttr "polyMergeVert6.out" "polyMergeVert7.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert7.mp";
connectAttr "polyMergeVert7.out" "polyMergeVert8.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert8.mp";
connectAttr "polyMergeVert8.out" "polyCrease1.ip";
connectAttr "polyCrease1.out" "polyTweak6.ip";
connectAttr "polyTweak6.out" "deleteComponent3.ig";
connectAttr "deleteComponent3.og" "deleteComponent4.ig";
connectAttr "deleteComponent4.og" "deleteComponent5.ig";
connectAttr "deleteComponent5.og" "deleteComponent6.ig";
connectAttr "deleteComponent6.og" "polyCrease2.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of viewingBox.ma
