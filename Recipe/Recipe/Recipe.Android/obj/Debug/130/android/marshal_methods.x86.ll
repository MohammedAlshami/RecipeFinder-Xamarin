; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [198 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 52
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 82
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 12
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 77
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 66
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 66
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 33
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 67
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 31
	i32 220171995, ; 9: System.Diagnostics.Debug => 0xd1f8edb => 96
	i32 230216969, ; 10: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 47
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 92
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 36
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 51
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 45
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 23
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 17
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 49
	i32 393699800, ; 18: Firebase => 0x177761d8 => 5
	i32 441335492, ; 19: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 35
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 76
	i32 442565967, ; 21: System.Collections => 0x1a61054f => 94
	i32 450948140, ; 22: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 44
	i32 465846621, ; 23: mscorlib => 0x1bc4415d => 11
	i32 469710990, ; 24: System.dll => 0x1bff388e => 16
	i32 476646585, ; 25: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 45
	i32 486930444, ; 26: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 56
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 86
	i32 545304856, ; 28: System.Runtime.Extensions => 0x2080b118 => 97
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 90
	i32 610194910, ; 30: System.Reactive.dll => 0x245ed5de => 19
	i32 627609679, ; 31: Xamarin.AndroidX.CustomView => 0x2568904f => 40
	i32 663517072, ; 32: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 72
	i32 666292255, ; 33: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 28
	i32 690569205, ; 34: System.Xml.Linq.dll => 0x29293ff5 => 22
	i32 774853013, ; 35: Recipe => 0x2e2f5195 => 14
	i32 775507847, ; 36: System.IO.Compression => 0x2e394f87 => 89
	i32 809851609, ; 37: System.Drawing.Common.dll => 0x30455ad9 => 88
	i32 843511501, ; 38: Xamarin.AndroidX.Print => 0x3246f6cd => 63
	i32 861712420, ; 39: Recipe.dll => 0x335cb024 => 14
	i32 928116545, ; 40: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 82
	i32 955402788, ; 41: Newtonsoft.Json => 0x38f24a24 => 12
	i32 967690846, ; 42: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 49
	i32 974778368, ; 43: FormsViewGroup.dll => 0x3a19f000 => 7
	i32 992768348, ; 44: System.Collections.dll => 0x3b2c715c => 94
	i32 1012816738, ; 45: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 65
	i32 1035644815, ; 46: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 27
	i32 1042160112, ; 47: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 79
	i32 1052210849, ; 48: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 53
	i32 1098259244, ; 49: System => 0x41761b2c => 16
	i32 1104002344, ; 50: Plugin.Media => 0x41cdbd28 => 13
	i32 1175144683, ; 51: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 70
	i32 1178241025, ; 52: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 60
	i32 1204270330, ; 53: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 28
	i32 1267360935, ; 54: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 71
	i32 1293217323, ; 55: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 42
	i32 1364015309, ; 56: System.IO => 0x514d38cd => 95
	i32 1365406463, ; 57: System.ServiceModel.Internals.dll => 0x516272ff => 83
	i32 1376866003, ; 58: Xamarin.AndroidX.SavedState => 0x52114ed3 => 65
	i32 1395857551, ; 59: Xamarin.AndroidX.Media.dll => 0x5333188f => 57
	i32 1406073936, ; 60: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 37
	i32 1457743152, ; 61: System.Runtime.Extensions.dll => 0x56e36530 => 97
	i32 1460219004, ; 62: Xamarin.Forms.Xaml => 0x57092c7c => 80
	i32 1462112819, ; 63: System.IO.Compression.dll => 0x57261233 => 89
	i32 1469204771, ; 64: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 26
	i32 1582372066, ; 65: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 41
	i32 1592978981, ; 66: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 67: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 55
	i32 1624863272, ; 68: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 74
	i32 1636350590, ; 69: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 39
	i32 1639515021, ; 70: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 71: System.Runtime => 0x62c6282e => 20
	i32 1658241508, ; 72: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 68
	i32 1658251792, ; 73: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 81
	i32 1670060433, ; 74: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 36
	i32 1701541528, ; 75: System.Diagnostics.Debug.dll => 0x656b7698 => 96
	i32 1729485958, ; 76: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 32
	i32 1766324549, ; 77: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 67
	i32 1776026572, ; 78: System.Core.dll => 0x69dc03cc => 15
	i32 1788241197, ; 79: Xamarin.AndroidX.Fragment => 0x6a96652d => 44
	i32 1808609942, ; 80: Xamarin.AndroidX.Loader => 0x6bcd3296 => 55
	i32 1813201214, ; 81: Xamarin.Google.Android.Material => 0x6c13413e => 81
	i32 1818569960, ; 82: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 61
	i32 1867746548, ; 83: Xamarin.Essentials.dll => 0x6f538cf4 => 76
	i32 1878053835, ; 84: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 80
	i32 1885316902, ; 85: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 29
	i32 1904755420, ; 86: System.Runtime.InteropServices.WindowsRuntime.dll => 0x718842dc => 2
	i32 1919157823, ; 87: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 58
	i32 2019465201, ; 88: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 53
	i32 2048185678, ; 89: Plugin.Media.dll => 0x7a14d54e => 13
	i32 2055257422, ; 90: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 50
	i32 2079903147, ; 91: System.Runtime.dll => 0x7bf8cdab => 20
	i32 2090596640, ; 92: System.Numerics.Vectors => 0x7c9bf920 => 18
	i32 2097448633, ; 93: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 46
	i32 2126786730, ; 94: Xamarin.Forms.Platform.Android => 0x7ec430aa => 78
	i32 2201231467, ; 95: System.Net.Http => 0x8334206b => 1
	i32 2216717168, ; 96: Firebase.Auth.dll => 0x84206b70 => 4
	i32 2217644978, ; 97: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 70
	i32 2244775296, ; 98: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 56
	i32 2256548716, ; 99: Xamarin.AndroidX.MultiDex => 0x8680336c => 58
	i32 2261435625, ; 100: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 48
	i32 2279755925, ; 101: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 64
	i32 2315684594, ; 102: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 24
	i32 2409053734, ; 103: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 62
	i32 2465532216, ; 104: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 35
	i32 2471841756, ; 105: netstandard.dll => 0x93554fdc => 84
	i32 2475788418, ; 106: Java.Interop.dll => 0x93918882 => 8
	i32 2501346920, ; 107: System.Data.DataSetExtensions => 0x95178668 => 87
	i32 2505896520, ; 108: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 52
	i32 2581819634, ; 109: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 71
	i32 2620871830, ; 110: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 39
	i32 2624644809, ; 111: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 43
	i32 2633051222, ; 112: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 51
	i32 2693849962, ; 113: System.IO.dll => 0xa090e36a => 95
	i32 2701096212, ; 114: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 68
	i32 2715334215, ; 115: System.Threading.Tasks.dll => 0xa1d8b647 => 93
	i32 2732626843, ; 116: Xamarin.AndroidX.Activity => 0xa2e0939b => 23
	i32 2737747696, ; 117: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 26
	i32 2766581644, ; 118: Xamarin.Forms.Core => 0xa4e6af8c => 77
	i32 2778768386, ; 119: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 73
	i32 2810250172, ; 120: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 37
	i32 2819470561, ; 121: System.Xml.dll => 0xa80db4e1 => 21
	i32 2853208004, ; 122: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 73
	i32 2855708567, ; 123: Xamarin.AndroidX.Transition => 0xaa36a797 => 69
	i32 2903344695, ; 124: System.ComponentModel.Composition => 0xad0d8637 => 91
	i32 2905242038, ; 125: mscorlib.dll => 0xad2a79b6 => 11
	i32 2916838712, ; 126: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 74
	i32 2919462931, ; 127: System.Numerics.Vectors.dll => 0xae037813 => 18
	i32 2921128767, ; 128: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 25
	i32 2978675010, ; 129: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 42
	i32 3024354802, ; 130: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 47
	i32 3044182254, ; 131: FormsViewGroup => 0xb57288ee => 7
	i32 3057625584, ; 132: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 59
	i32 3075834255, ; 133: System.Threading.Tasks => 0xb755818f => 93
	i32 3111772706, ; 134: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 135: System.Data.dll => 0xbefef58f => 85
	i32 3211777861, ; 136: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 41
	i32 3247949154, ; 137: Mono.Security => 0xc197c562 => 98
	i32 3258312781, ; 138: Xamarin.AndroidX.CardView => 0xc235e84d => 32
	i32 3267021929, ; 139: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 30
	i32 3317135071, ; 140: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 40
	i32 3317144872, ; 141: System.Data => 0xc5b79d28 => 85
	i32 3322403133, ; 142: Firebase.dll => 0xc607d93d => 5
	i32 3340431453, ; 143: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 29
	i32 3346324047, ; 144: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 60
	i32 3353484488, ; 145: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 46
	i32 3353544232, ; 146: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 75
	i32 3362522851, ; 147: Xamarin.AndroidX.Core => 0xc86c06e3 => 38
	i32 3366347497, ; 148: Java.Interop => 0xc8a662e9 => 8
	i32 3374999561, ; 149: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 64
	i32 3404865022, ; 150: System.ServiceModel.Internals => 0xcaf21dfe => 83
	i32 3407215217, ; 151: Xamarin.CommunityToolkit => 0xcb15fa71 => 75
	i32 3429136800, ; 152: System.Xml => 0xcc6479a0 => 21
	i32 3430777524, ; 153: netstandard => 0xcc7d82b4 => 84
	i32 3441283291, ; 154: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 43
	i32 3476120550, ; 155: Mono.Android => 0xcf3163e6 => 10
	i32 3477605072, ; 156: Recipe.Android => 0xcf480ad0 => 0
	i32 3486566296, ; 157: System.Transactions => 0xcfd0c798 => 86
	i32 3493954962, ; 158: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 34
	i32 3501239056, ; 159: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 30
	i32 3509114376, ; 160: System.Xml.Linq => 0xd128d608 => 22
	i32 3536029504, ; 161: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 78
	i32 3567349600, ; 162: System.ComponentModel.Composition.dll => 0xd4a16f60 => 91
	i32 3587891622, ; 163: Recipe.Android.dll => 0xd5dae1a6 => 0
	i32 3596207933, ; 164: LiteDB.dll => 0xd659c73d => 9
	i32 3618140916, ; 165: Xamarin.AndroidX.Preference => 0xd7a872f4 => 62
	i32 3627220390, ; 166: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 63
	i32 3629588173, ; 167: LiteDB => 0xd8571ecd => 9
	i32 3632359727, ; 168: Xamarin.Forms.Platform => 0xd881692f => 79
	i32 3633644679, ; 169: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 25
	i32 3641597786, ; 170: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 50
	i32 3655481159, ; 171: Firebase.Storage => 0xd9e23747 => 6
	i32 3672681054, ; 172: Mono.Android.dll => 0xdae8aa5e => 10
	i32 3676310014, ; 173: System.Web.Services.dll => 0xdb2009fe => 92
	i32 3682565725, ; 174: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 31
	i32 3684561358, ; 175: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 34
	i32 3684933406, ; 176: System.Runtime.InteropServices.WindowsRuntime => 0xdba39f1e => 2
	i32 3689375977, ; 177: System.Drawing.Common => 0xdbe768e9 => 88
	i32 3718780102, ; 178: Xamarin.AndroidX.Annotation => 0xdda814c6 => 24
	i32 3724971120, ; 179: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 59
	i32 3731644420, ; 180: System.Reactive => 0xde6c6004 => 19
	i32 3758932259, ; 181: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 48
	i32 3786282454, ; 182: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 33
	i32 3822602673, ; 183: Xamarin.AndroidX.Media => 0xe3d849b1 => 57
	i32 3829621856, ; 184: System.Numerics.dll => 0xe4436460 => 17
	i32 3885922214, ; 185: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 69
	i32 3896760992, ; 186: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 38
	i32 3920810846, ; 187: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 90
	i32 3921031405, ; 188: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 72
	i32 3929187773, ; 189: Firebase.Storage.dll => 0xea32a5bd => 6
	i32 3931092270, ; 190: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 61
	i32 3945713374, ; 191: System.Data.DataSetExtensions.dll => 0xeb2ecede => 87
	i32 3955647286, ; 192: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 27
	i32 4024013275, ; 193: Firebase.Auth => 0xefd991db => 4
	i32 4105002889, ; 194: Mono.Security.dll => 0xf4ad5f89 => 98
	i32 4151237749, ; 195: System.Core => 0xf76edc75 => 15
	i32 4182413190, ; 196: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 54
	i32 4292120959 ; 197: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 54
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [198 x i32] [
	i32 52, i32 82, i32 12, i32 77, i32 66, i32 66, i32 33, i32 67, ; 0..7
	i32 31, i32 96, i32 47, i32 92, i32 36, i32 51, i32 45, i32 23, ; 8..15
	i32 17, i32 49, i32 5, i32 35, i32 76, i32 94, i32 44, i32 11, ; 16..23
	i32 16, i32 45, i32 56, i32 86, i32 97, i32 90, i32 19, i32 40, ; 24..31
	i32 72, i32 28, i32 22, i32 14, i32 89, i32 88, i32 63, i32 14, ; 32..39
	i32 82, i32 12, i32 49, i32 7, i32 94, i32 65, i32 27, i32 79, ; 40..47
	i32 53, i32 16, i32 13, i32 70, i32 60, i32 28, i32 71, i32 42, ; 48..55
	i32 95, i32 83, i32 65, i32 57, i32 37, i32 97, i32 80, i32 89, ; 56..63
	i32 26, i32 41, i32 3, i32 55, i32 74, i32 39, i32 1, i32 20, ; 64..71
	i32 68, i32 81, i32 36, i32 96, i32 32, i32 67, i32 15, i32 44, ; 72..79
	i32 55, i32 81, i32 61, i32 76, i32 80, i32 29, i32 2, i32 58, ; 80..87
	i32 53, i32 13, i32 50, i32 20, i32 18, i32 46, i32 78, i32 1, ; 88..95
	i32 4, i32 70, i32 56, i32 58, i32 48, i32 64, i32 24, i32 62, ; 96..103
	i32 35, i32 84, i32 8, i32 87, i32 52, i32 71, i32 39, i32 43, ; 104..111
	i32 51, i32 95, i32 68, i32 93, i32 23, i32 26, i32 77, i32 73, ; 112..119
	i32 37, i32 21, i32 73, i32 69, i32 91, i32 11, i32 74, i32 18, ; 120..127
	i32 25, i32 42, i32 47, i32 7, i32 59, i32 93, i32 3, i32 85, ; 128..135
	i32 41, i32 98, i32 32, i32 30, i32 40, i32 85, i32 5, i32 29, ; 136..143
	i32 60, i32 46, i32 75, i32 38, i32 8, i32 64, i32 83, i32 75, ; 144..151
	i32 21, i32 84, i32 43, i32 10, i32 0, i32 86, i32 34, i32 30, ; 152..159
	i32 22, i32 78, i32 91, i32 0, i32 9, i32 62, i32 63, i32 9, ; 160..167
	i32 79, i32 25, i32 50, i32 6, i32 10, i32 92, i32 31, i32 34, ; 168..175
	i32 2, i32 88, i32 24, i32 59, i32 19, i32 48, i32 33, i32 57, ; 176..183
	i32 17, i32 69, i32 38, i32 90, i32 72, i32 6, i32 61, i32 87, ; 184..191
	i32 27, i32 4, i32 98, i32 15, i32 54, i32 54 ; 192..197
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
