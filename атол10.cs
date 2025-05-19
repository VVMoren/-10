using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using Gbs.Core.Config;
using Gbs.Core.Devices.CheckPrinters.CheckData;
using Gbs.Core.Entities;
using Gbs.Forms.Settings;
using Gbs.Helpers;
using Gbs.Helpers.ErrorHandler;
using Gbs.Helpers.Logging;
using Gbs.Helpers.MarkCodes;
using Gbs.Resources.Localizations;
using Microsoft.CSharp.RuntimeBinder;

namespace Gbs.Core.Devices.CheckPrinters.FiscalKkm.Models
{
	// Token: 0x02000610 RID: 1552
	public class Atol10 : IOnlineKkm, IFiscalKkm, IDevice
	{
		// Token: 0x060053EF RID: 21487 RVA: 0x001201D5 File Offset: 0x0011E3D5
		public IDevice.DeviceTypes Type()
		{
			return IDevice.DeviceTypes.Kkm;
		}

		// Token: 0x1700275A RID: 10074
		// (get) Token: 0x060053F0 RID: 21488 RVA: 0x001201D8 File Offset: 0x0011E3D8
		public string Name
		{
			get
			{
				return Translate.Atol10_Name_АТОЛ_v_10;
			}
		}

		// Token: 0x1700275B RID: 10075
		// (get) Token: 0x060053F1 RID: 21489 RVA: 0x001201DF File Offset: 0x0011E3DF
		// (set) Token: 0x060053F2 RID: 21490 RVA: 0x001201E7 File Offset: 0x0011E3E7
		[Dynamic]
		private dynamic AtolDriver
		{
			[return: Dynamic]
			get;
			[param: Dynamic]
			set;
		}

		// Token: 0x1700275C RID: 10076
		// (get) Token: 0x060053F3 RID: 21491 RVA: 0x001201F0 File Offset: 0x0011E3F0
		// (set) Token: 0x060053F4 RID: 21492 RVA: 0x001201F8 File Offset: 0x0011E3F8
		private Devices DevicesConfig { get; set; }

		// Token: 0x060053F5 RID: 21493 RVA: 0x00120201 File Offset: 0x0011E401
		public Atol10(Devices devicesConfig)
		{
			this.DevicesConfig = devicesConfig;
		}

		// Token: 0x060053F6 RID: 21494 RVA: 0x00120210 File Offset: 0x0011E410
		private void CheckResult()
		{
			if (Atol10.<>o__12.<>p__1 == null)
			{
				Atol10.<>o__12.<>p__1 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target = Atol10.<>o__12.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__12.<>p__1;
			if (Atol10.<>o__12.<>p__0 == null)
			{
				Atol10.<>o__12.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			int resultCode = target(<>p__, Atol10.<>o__12.<>p__0.Target(Atol10.<>o__12.<>p__0, this.AtolDriver));
			if (resultCode == 0)
			{
				return;
			}
			if (resultCode == 177)
			{
				LogHelper.Debug("Ошибка 177. Пытаемся допечатать документ");
				if (Atol10.<>o__12.<>p__2 == null)
				{
					Atol10.<>o__12.<>p__2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "continuePrint", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__12.<>p__2.Target(Atol10.<>o__12.<>p__2, this.AtolDriver);
				if (Atol10.<>o__12.<>p__4 == null)
				{
					Atol10.<>o__12.<>p__4 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
				}
				Func<CallSite, object, int> target2 = Atol10.<>o__12.<>p__4.Target;
				CallSite <>p__2 = Atol10.<>o__12.<>p__4;
				if (Atol10.<>o__12.<>p__3 == null)
				{
					Atol10.<>o__12.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				resultCode = target2(<>p__2, Atol10.<>o__12.<>p__3.Target(Atol10.<>o__12.<>p__3, this.AtolDriver));
				LogHelper.Debug("Результат допечатования: " + resultCode.ToString());
				if (resultCode == 0)
				{
					return;
				}
			}
			if (Atol10.<>o__12.<>p__6 == null)
			{
				Atol10.<>o__12.<>p__6 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(Atol10)));
			}
			Func<CallSite, object, string> target3 = Atol10.<>o__12.<>p__6.Target;
			CallSite <>p__3 = Atol10.<>o__12.<>p__6;
			if (Atol10.<>o__12.<>p__5 == null)
			{
				Atol10.<>o__12.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorDescription", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			string kkmResultDescription = target3(<>p__3, Atol10.<>o__12.<>p__5.Target(Atol10.<>o__12.<>p__5, this.AtolDriver));
			string deviceMsg = string.Format(Translate.Код___0____Описание___1_, resultCode, kkmResultDescription);
			KkmException.ErrorTypes errorTypes;
			if (resultCode <= 35)
			{
				switch (resultCode)
				{
				case 1:
					errorTypes = KkmException.ErrorTypes.NoConnection;
					goto IL_02D9;
				case 2:
					errorTypes = KkmException.ErrorTypes.NoConnection;
					goto IL_02D9;
				case 3:
					errorTypes = KkmException.ErrorTypes.PortBusy;
					goto IL_02D9;
				case 4:
					errorTypes = KkmException.ErrorTypes.NoConnection;
					goto IL_02D9;
				case 5:
					errorTypes = KkmException.ErrorTypes.NonCorrectData;
					goto IL_02D9;
				default:
					if (resultCode == 35)
					{
						errorTypes = KkmException.ErrorTypes.UnCorrectDateTime;
						goto IL_02D9;
					}
					break;
				}
			}
			else
			{
				switch (resultCode)
				{
				case 44:
					errorTypes = KkmException.ErrorTypes.NoPaper;
					goto IL_02D9;
				case 45:
					errorTypes = KkmException.ErrorTypes.NoPaper;
					goto IL_02D9;
				case 46:
					break;
				case 47:
					errorTypes = KkmException.ErrorTypes.NeedService;
					goto IL_02D9;
				default:
					if (resultCode == 68)
					{
						errorTypes = KkmException.ErrorTypes.SessionMore24Hour;
						goto IL_02D9;
					}
					if (resultCode == 137)
					{
						errorTypes = KkmException.ErrorTypes.TooManyOfflineDocuments;
						goto IL_02D9;
					}
					break;
				}
			}
			errorTypes = KkmException.ErrorTypes.Unknown;
			IL_02D9:
			KkmException.ErrorTypes errType = errorTypes;
			throw new ErrorHelper.GbsException(KkmException.ErrorsDictionary[errType] + "\n" + deviceMsg)
			{
				Direction = ((errType == KkmException.ErrorTypes.Unknown) ? ErrorHelper.ErrorDirections.Unknown : ErrorHelper.ErrorDirections.Outer)
			};
		}

		// Token: 0x060053F7 RID: 21495 RVA: 0x00120524 File Offset: 0x0011E724
		private void WriteOfdAttribute(int ofdAttributeNumber, object value)
		{
			if (value == null || value.ToString().IsNullOrEmpty())
			{
				return;
			}
			LogHelper.Debug(string.Format("Запись атрибута: number: {0}; value: {1}", ofdAttributeNumber, value));
			if (Atol10.<>o__13.<>p__0 == null)
			{
				Atol10.<>o__13.<>p__0 = CallSite<Action<CallSite, object, int, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Atol10.<>o__13.<>p__0.Target(Atol10.<>o__13.<>p__0, this.AtolDriver, ofdAttributeNumber, value);
			this.CheckResult();
		}

		// Token: 0x060053F8 RID: 21496 RVA: 0x001205CC File Offset: 0x0011E7CC
		private KkmStatuses GetKkmState()
		{
			KkmStatuses s = KkmStatuses.Ready;
			if (Atol10.<>o__14.<>p__2 == null)
			{
				Atol10.<>o__14.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__14.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__14.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__14.<>p__0 == null)
			{
				Atol10.<>o__14.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__14.<>p__0.Target(Atol10.<>o__14.<>p__0, this.AtolDriver);
			if (Atol10.<>o__14.<>p__1 == null)
			{
				Atol10.<>o__14.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_SHORT_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__14.<>p__1.Target(Atol10.<>o__14.<>p__1, this.AtolDriver));
			if (Atol10.<>o__14.<>p__3 == null)
			{
				Atol10.<>o__14.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__14.<>p__3.Target(Atol10.<>o__14.<>p__3, this.AtolDriver);
			if (Atol10.<>o__14.<>p__6 == null)
			{
				Atol10.<>o__14.<>p__6 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target2 = Atol10.<>o__14.<>p__6.Target;
			CallSite <>p__2 = Atol10.<>o__14.<>p__6;
			if (Atol10.<>o__14.<>p__5 == null)
			{
				Atol10.<>o__14.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamBool", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target3 = Atol10.<>o__14.<>p__5.Target;
			CallSite <>p__3 = Atol10.<>o__14.<>p__5;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__14.<>p__4 == null)
			{
				Atol10.<>o__14.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_COVER_OPENED", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			if (target2(<>p__2, target3(<>p__3, atolDriver2, Atol10.<>o__14.<>p__4.Target(Atol10.<>o__14.<>p__4, this.AtolDriver))))
			{
				s = KkmStatuses.CoverOpen;
			}
			if (Atol10.<>o__14.<>p__10 == null)
			{
				Atol10.<>o__14.<>p__10 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target4 = Atol10.<>o__14.<>p__10.Target;
			CallSite <>p__4 = Atol10.<>o__14.<>p__10;
			if (Atol10.<>o__14.<>p__9 == null)
			{
				Atol10.<>o__14.<>p__9 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Func<CallSite, object, bool, object> target5 = Atol10.<>o__14.<>p__9.Target;
			CallSite <>p__5 = Atol10.<>o__14.<>p__9;
			if (Atol10.<>o__14.<>p__8 == null)
			{
				Atol10.<>o__14.<>p__8 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamBool", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target6 = Atol10.<>o__14.<>p__8.Target;
			CallSite <>p__6 = Atol10.<>o__14.<>p__8;
			object atolDriver3 = this.AtolDriver;
			if (Atol10.<>o__14.<>p__7 == null)
			{
				Atol10.<>o__14.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_PAPER_PRESENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			if (target4(<>p__4, target5(<>p__5, target6(<>p__6, atolDriver3, Atol10.<>o__14.<>p__7.Target(Atol10.<>o__14.<>p__7, this.AtolDriver)), false)))
			{
				s = KkmStatuses.NoPaper;
			}
			if (new ConfigsRepository<Devices>().Get().CheckPrinter.FiscalKkm.FfdVersion != GlobalDictionaries.Devices.FfdVersions.OfflineKkm)
			{
				if (Atol10.<>o__14.<>p__13 == null)
				{
					Atol10.<>o__14.<>p__13 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target7 = Atol10.<>o__14.<>p__13.Target;
				CallSite <>p__7 = Atol10.<>o__14.<>p__13;
				object atolDriver4 = this.AtolDriver;
				if (Atol10.<>o__14.<>p__11 == null)
				{
					Atol10.<>o__14.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FN_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = Atol10.<>o__14.<>p__11.Target(Atol10.<>o__14.<>p__11, this.AtolDriver);
				if (Atol10.<>o__14.<>p__12 == null)
				{
					Atol10.<>o__14.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_FNDT_OFD_EXCHANGE_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target7(<>p__7, atolDriver4, obj2, Atol10.<>o__14.<>p__12.Target(Atol10.<>o__14.<>p__12, this.AtolDriver));
				if (Atol10.<>o__14.<>p__14 == null)
				{
					Atol10.<>o__14.<>p__14 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "fnQueryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__14.<>p__14.Target(Atol10.<>o__14.<>p__14, this.AtolDriver);
				if (Atol10.<>o__14.<>p__16 == null)
				{
					Atol10.<>o__14.<>p__16 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object, object> target8 = Atol10.<>o__14.<>p__16.Target;
				CallSite <>p__8 = Atol10.<>o__14.<>p__16;
				object atolDriver5 = this.AtolDriver;
				if (Atol10.<>o__14.<>p__15 == null)
				{
					Atol10.<>o__14.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DOCUMENTS_COUNT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object noSendDocs = target8(<>p__8, atolDriver5, Atol10.<>o__14.<>p__15.Target(Atol10.<>o__14.<>p__15, this.AtolDriver));
				if (Atol10.<>o__14.<>p__18 == null)
				{
					Atol10.<>o__14.<>p__18 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target9 = Atol10.<>o__14.<>p__18.Target;
				CallSite <>p__9 = Atol10.<>o__14.<>p__18;
				if (Atol10.<>o__14.<>p__17 == null)
				{
					Atol10.<>o__14.<>p__17 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target9(<>p__9, Atol10.<>o__14.<>p__17.Target(Atol10.<>o__14.<>p__17, noSendDocs, 0)))
				{
					if (Atol10.<>o__14.<>p__24 == null)
					{
						Atol10.<>o__14.<>p__24 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target10 = Atol10.<>o__14.<>p__24.Target;
					CallSite <>p__10 = Atol10.<>o__14.<>p__24;
					if (Atol10.<>o__14.<>p__23 == null)
					{
						Atol10.<>o__14.<>p__23 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.GreaterThan, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Func<CallSite, object, int, object> target11 = Atol10.<>o__14.<>p__23.Target;
					CallSite <>p__11 = Atol10.<>o__14.<>p__23;
					if (Atol10.<>o__14.<>p__22 == null)
					{
						Atol10.<>o__14.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "TotalDays", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, object> target12 = Atol10.<>o__14.<>p__22.Target;
					CallSite <>p__12 = Atol10.<>o__14.<>p__22;
					if (Atol10.<>o__14.<>p__21 == null)
					{
						Atol10.<>o__14.<>p__21 = CallSite<Func<CallSite, DateTime, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Subtract, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, DateTime, object, object> target13 = Atol10.<>o__14.<>p__21.Target;
					CallSite <>p__13 = Atol10.<>o__14.<>p__21;
					DateTime now = DateTime.Now;
					if (Atol10.<>o__14.<>p__20 == null)
					{
						Atol10.<>o__14.<>p__20 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamDateTime", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target14 = Atol10.<>o__14.<>p__20.Target;
					CallSite <>p__14 = Atol10.<>o__14.<>p__20;
					object atolDriver6 = this.AtolDriver;
					if (Atol10.<>o__14.<>p__19 == null)
					{
						Atol10.<>o__14.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATE_TIME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					if (target10(<>p__10, target11(<>p__11, target12(<>p__12, target13(<>p__13, now, target14(<>p__14, atolDriver6, Atol10.<>o__14.<>p__19.Target(Atol10.<>o__14.<>p__19, this.AtolDriver)))), 25)))
					{
						s = KkmStatuses.OfdDocumentsToMany;
					}
				}
				if (Atol10.<>o__14.<>p__27 == null)
				{
					Atol10.<>o__14.<>p__27 = CallSite<Action<CallSite, global::System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Debug", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, Type, object> target15 = Atol10.<>o__14.<>p__27.Target;
				CallSite <>p__15 = Atol10.<>o__14.<>p__27;
				Type typeFromHandle = typeof(LogHelper);
				if (Atol10.<>o__14.<>p__26 == null)
				{
					Atol10.<>o__14.<>p__26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Func<CallSite, object, string, object> target16 = Atol10.<>o__14.<>p__26.Target;
				CallSite <>p__16 = Atol10.<>o__14.<>p__26;
				if (Atol10.<>o__14.<>p__25 == null)
				{
					Atol10.<>o__14.<>p__25 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				target15(<>p__15, typeFromHandle, target16(<>p__16, Atol10.<>o__14.<>p__25.Target(Atol10.<>o__14.<>p__25, "В ОФД неотправлено ", noSendDocs), " документов"));
			}
			return s;
		}

		// Token: 0x060053F9 RID: 21497 RVA: 0x00120F38 File Offset: 0x0011F138
		public bool SendDigitalCheck(string address)
		{
			bool r = !string.IsNullOrEmpty(address) && this.WriteOfdAttribute(OfdAttributes.ClientEmailPhone, address);
			if (r && this.DevicesConfig.CheckPrinter.FiscalKkm.IsNoPrintCheckIfSendDigitalCheck)
			{
				if (Atol10.<>o__15.<>p__1 == null)
				{
					Atol10.<>o__15.<>p__1 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, bool> target = Atol10.<>o__15.<>p__1.Target;
				CallSite <>p__ = Atol10.<>o__15.<>p__1;
				object atolDriver = this.AtolDriver;
				if (Atol10.<>o__15.<>p__0 == null)
				{
					Atol10.<>o__15.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_ELECTRONICALLY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target(<>p__, atolDriver, Atol10.<>o__15.<>p__0.Target(Atol10.<>o__15.<>p__0, this.AtolDriver), true);
			}
			return r;
		}

		// Token: 0x1700275D RID: 10077
		// (get) Token: 0x060053FA RID: 21498 RVA: 0x00121038 File Offset: 0x0011F238
		public KkmLastActionResult LasActionResult
		{
			get
			{
				return new KkmLastActionResult
				{
					ActionResult = ActionsResults.Done
				};
			}
		}

		// Token: 0x1700275E RID: 10078
		// (get) Token: 0x060053FB RID: 21499 RVA: 0x00121046 File Offset: 0x0011F246
		public bool IsCanHoldConnection
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060053FC RID: 21500 RVA: 0x0012104C File Offset: 0x0011F24C
		public void ShowProperties()
		{
			LogHelper.Debug("Открываем настройки ККМ Атол");
			int r;
			try
			{
				if (Atol10.<>o__20.<>p__2 == null)
				{
					Atol10.<>o__20.<>p__2 = CallSite<Func<CallSite, global::System.Type, object, Version>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, Type, object, Version> target = Atol10.<>o__20.<>p__2.Target;
				CallSite <>p__ = Atol10.<>o__20.<>p__2;
				Type typeFromHandle = typeof(Version);
				if (Atol10.<>o__20.<>p__1 == null)
				{
					Atol10.<>o__20.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, object> target2 = Atol10.<>o__20.<>p__1.Target;
				CallSite <>p__2 = Atol10.<>o__20.<>p__1;
				if (Atol10.<>o__20.<>p__0 == null)
				{
					Atol10.<>o__20.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "version", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				if (target(<>p__, typeFromHandle, target2(<>p__2, Atol10.<>o__20.<>p__0.Target(Atol10.<>o__20.<>p__0, this.AtolDriver))) > new Version(10, 7))
				{
					IntPtr h = IntPtr.Zero;
					using (IEnumerator<FrmSettings> enumerator = Application.Current.Windows.OfType<FrmSettings>().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							h = new WindowInteropHelper(enumerator.Current).Handle;
						}
					}
					LogHelper.Debug("открываем с объектом окна");
					if (Atol10.<>o__20.<>p__5 == null)
					{
						Atol10.<>o__20.<>p__5 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Atol10)));
					}
					Func<CallSite, object, int> target3 = Atol10.<>o__20.<>p__5.Target;
					CallSite <>p__3 = Atol10.<>o__20.<>p__5;
					if (Atol10.<>o__20.<>p__4 == null)
					{
						Atol10.<>o__20.<>p__4 = CallSite<Func<CallSite, object, object, IntPtr, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "showProperties", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Func<CallSite, object, object, IntPtr, object> target4 = Atol10.<>o__20.<>p__4.Target;
					CallSite <>p__4 = Atol10.<>o__20.<>p__4;
					object atolDriver = this.AtolDriver;
					if (Atol10.<>o__20.<>p__3 == null)
					{
						Atol10.<>o__20.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_GUI_PARENT_NATIVE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					r = target3(<>p__3, target4(<>p__4, atolDriver, Atol10.<>o__20.<>p__3.Target(Atol10.<>o__20.<>p__3, this.AtolDriver), h));
				}
				else
				{
					LogHelper.Debug("открываем без обхекта окна");
					if (Atol10.<>o__20.<>p__7 == null)
					{
						Atol10.<>o__20.<>p__7 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Atol10)));
					}
					Func<CallSite, object, int> target5 = Atol10.<>o__20.<>p__7.Target;
					CallSite <>p__5 = Atol10.<>o__20.<>p__7;
					if (Atol10.<>o__20.<>p__6 == null)
					{
						Atol10.<>o__20.<>p__6 = CallSite<Func<CallSite, object, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "showProperties", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					r = target5(<>p__5, Atol10.<>o__20.<>p__6.Target(Atol10.<>o__20.<>p__6, this.AtolDriver, null, null));
				}
			}
			catch
			{
				LogHelper.Debug("открываем без объекта, была ошибка");
				if (Atol10.<>o__20.<>p__9 == null)
				{
					Atol10.<>o__20.<>p__9 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Atol10)));
				}
				Func<CallSite, object, int> target6 = Atol10.<>o__20.<>p__9.Target;
				CallSite <>p__6 = Atol10.<>o__20.<>p__9;
				if (Atol10.<>o__20.<>p__8 == null)
				{
					Atol10.<>o__20.<>p__8 = CallSite<Func<CallSite, object, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "showProperties", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				r = target6(<>p__6, Atol10.<>o__20.<>p__8.Target(Atol10.<>o__20.<>p__8, this.AtolDriver, null, null));
			}
			FiscalKkm fiscalKkm = this.DevicesConfig.CheckPrinter.FiscalKkm;
			if (Atol10.<>o__20.<>p__11 == null)
			{
				Atol10.<>o__20.<>p__11 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Atol10)));
			}
			Func<CallSite, object, string> target7 = Atol10.<>o__20.<>p__11.Target;
			CallSite<Func<CallSite, object, string>> <>p__7 = Atol10.<>o__20.<>p__11;
			if (r != -1)
			{
				object obj;
				if (r == 0)
				{
					if (Atol10.<>o__20.<>p__10 == null)
					{
						Atol10.<>o__20.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getSettings", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					obj = Atol10.<>o__20.<>p__10.Target(Atol10.<>o__20.<>p__10, this.AtolDriver);
				}
				else
				{
					obj = this.DevicesConfig.CheckPrinter.FiscalKkm.Atol10ConnectionConfig;
				}
				fiscalKkm.Atol10ConnectionConfig = target7(<>p__7, obj);
				return;
			}
			throw new ErrorHelper.GbsException(Translate.Atol10_Не_удалось_открыть_окно_настроек_драйвера);
		}

		// Token: 0x060053FD RID: 21501 RVA: 0x00121530 File Offset: 0x0011F730
		public void OpenSession(Cashier cashier)
		{
			this.OperatorLogin(cashier);
			if (Atol10.<>o__21.<>p__0 == null)
			{
				Atol10.<>o__21.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "openShift", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__21.<>p__0.Target(Atol10.<>o__21.<>p__0, this.AtolDriver);
			if (Atol10.<>o__21.<>p__1 == null)
			{
				Atol10.<>o__21.<>p__1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "checkDocumentClosed", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__21.<>p__1.Target(Atol10.<>o__21.<>p__1, this.AtolDriver);
			this.CheckResult();
		}

		// Token: 0x060053FE RID: 21502 RVA: 0x001215F4 File Offset: 0x0011F7F4
		public void GetReport(ReportTypes reportType, Cashier cashier)
		{
			Devices dc = new ConfigsRepository<Devices>().Get();
			switch (reportType)
			{
			case ReportTypes.ZReport:
			{
				if (dc.CheckPrinter.FiscalKkm.FfdVersion != GlobalDictionaries.Devices.FfdVersions.OfflineKkm)
				{
					this.OperatorLogin(cashier);
				}
				if (Atol10.<>o__22.<>p__2 == null)
				{
					Atol10.<>o__22.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target = Atol10.<>o__22.<>p__2.Target;
				CallSite <>p__ = Atol10.<>o__22.<>p__2;
				object atolDriver = this.AtolDriver;
				if (Atol10.<>o__22.<>p__0 == null)
				{
					Atol10.<>o__22.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_REPORT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj = Atol10.<>o__22.<>p__0.Target(Atol10.<>o__22.<>p__0, this.AtolDriver);
				if (Atol10.<>o__22.<>p__1 == null)
				{
					Atol10.<>o__22.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_CLOSE_SHIFT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target(<>p__, atolDriver, obj, Atol10.<>o__22.<>p__1.Target(Atol10.<>o__22.<>p__1, this.AtolDriver));
				break;
			}
			case ReportTypes.XReport:
			{
				if (Atol10.<>o__22.<>p__5 == null)
				{
					Atol10.<>o__22.<>p__5 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target2 = Atol10.<>o__22.<>p__5.Target;
				CallSite <>p__2 = Atol10.<>o__22.<>p__5;
				object atolDriver2 = this.AtolDriver;
				if (Atol10.<>o__22.<>p__3 == null)
				{
					Atol10.<>o__22.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_REPORT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = Atol10.<>o__22.<>p__3.Target(Atol10.<>o__22.<>p__3, this.AtolDriver);
				if (Atol10.<>o__22.<>p__4 == null)
				{
					Atol10.<>o__22.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_X", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(<>p__2, atolDriver2, obj2, Atol10.<>o__22.<>p__4.Target(Atol10.<>o__22.<>p__4, this.AtolDriver));
				break;
			}
			case ReportTypes.XReportWithGoods:
				throw new NotSupportedException();
			default:
				throw new ArgumentOutOfRangeException("reportType", reportType, null);
			}
			if (Atol10.<>o__22.<>p__6 == null)
			{
				Atol10.<>o__22.<>p__6 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "report", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__22.<>p__6.Target(Atol10.<>o__22.<>p__6, this.AtolDriver);
			this.CheckResult();
			if (Atol10.<>o__22.<>p__7 == null)
			{
				Atol10.<>o__22.<>p__7 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "checkDocumentClosed", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__22.<>p__7.Target(Atol10.<>o__22.<>p__7, this.AtolDriver);
			this.CheckResult();
		}

		// Token: 0x060053FF RID: 21503 RVA: 0x00121924 File Offset: 0x0011FB24
		public bool OpenCheck(CheckData checkData)
		{
			this._checkData = checkData;
			LogHelper.Debug("Открытие чека АТОЛ 10");
			Devices dc = new ConfigsRepository<Devices>().Get();
			if (dc.CheckPrinter.FiscalKkm.FfdVersion == GlobalDictionaries.Devices.FfdVersions.Ffd120)
			{
				this.Ffd120CodeValidation(checkData);
			}
			if (dc.CheckPrinter.FiscalKkm.FfdVersion != GlobalDictionaries.Devices.FfdVersions.OfflineKkm)
			{
				this.OperatorLogin(checkData.Cashier);
				int num;
				switch (checkData.RuTaxSystem)
				{
				case GlobalDictionaries.RuTaxSystems.None:
					num = 0;
					break;
				case GlobalDictionaries.RuTaxSystems.Osn:
					num = 1;
					break;
				case GlobalDictionaries.RuTaxSystems.UsnDohod:
					num = 2;
					break;
				case GlobalDictionaries.RuTaxSystems.UsnDohodMinusRashod:
					num = 4;
					break;
				case GlobalDictionaries.RuTaxSystems.Envd:
					num = 8;
					break;
				case GlobalDictionaries.RuTaxSystems.Esn:
					num = 16;
					break;
				case GlobalDictionaries.RuTaxSystems.Psn:
					num = 32;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				int ofdTaxCode = num;
				if (ofdTaxCode > 0)
				{
					this.WriteOfdAttribute(OfdAttributes.TaxSystem, ofdTaxCode);
				}
				if (checkData.Client != null)
				{
					if (dc.CheckPrinter.FiscalKkm.FfdVersion.IsEither(new GlobalDictionaries.Devices.FfdVersions[]
					{
						GlobalDictionaries.Devices.FfdVersions.Ffd105,
						GlobalDictionaries.Devices.FfdVersions.Ffd110
					}))
					{
						this.WriteOfdAttribute(OfdAttributes.ClientName, checkData.Client.Client.Name);
						EntityProperties.PropertyValue propertyValue = checkData.Client.Client.Properties.FirstOrDefault((EntityProperties.PropertyValue x) => x.Type.Uid == GlobalDictionaries.InnUid);
						string text;
						if (propertyValue == null)
						{
							text = null;
						}
						else
						{
							object value = propertyValue.Value;
							text = ((value != null) ? value.ToString() : null);
						}
						string clientInn = text ?? "";
						if (!clientInn.IsNullOrEmpty())
						{
							this.WriteOfdAttribute(OfdAttributes.ClientInn, clientInn);
						}
					}
					if (dc.CheckPrinter.FiscalKkm.FfdVersion.IsEither(new GlobalDictionaries.Devices.FfdVersions[] { GlobalDictionaries.Devices.FfdVersions.Ffd120 }))
					{
						if (Atol10.<>o__24.<>p__0 == null)
						{
							Atol10.<>o__24.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "utilFormTlv", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Atol10.<>o__24.<>p__0.Target(Atol10.<>o__24.<>p__0, this.AtolDriver);
						if (Atol10.<>o__24.<>p__1 == null)
						{
							Atol10.<>o__24.<>p__1 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Atol10.<>o__24.<>p__1.Target(Atol10.<>o__24.<>p__1, this.AtolDriver, 1227, checkData.Client.Client.Name);
						EntityProperties.PropertyValue propertyValue2 = checkData.Client.Client.Properties.FirstOrDefault((EntityProperties.PropertyValue x) => x.Type.Uid == GlobalDictionaries.InnUid);
						string text2;
						if (propertyValue2 == null)
						{
							text2 = null;
						}
						else
						{
							object value2 = propertyValue2.Value;
							text2 = ((value2 != null) ? value2.ToString() : null);
						}
						string clientInn2 = text2 ?? "";
						if (!clientInn2.IsNullOrEmpty())
						{
							if (Atol10.<>o__24.<>p__2 == null)
							{
								Atol10.<>o__24.<>p__2 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							Atol10.<>o__24.<>p__2.Target(Atol10.<>o__24.<>p__2, this.AtolDriver, 1228, clientInn2);
						}
						if (Atol10.<>o__24.<>p__3 == null)
						{
							Atol10.<>o__24.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "utilFormTlv", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Atol10.<>o__24.<>p__3.Target(Atol10.<>o__24.<>p__3, this.AtolDriver);
						Thread.Sleep(1000);
						if (Atol10.<>o__24.<>p__6 == null)
						{
							Atol10.<>o__24.<>p__6 = CallSite<Func<CallSite, object, byte[]>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte[]), typeof(Atol10)));
						}
						Func<CallSite, object, byte[]> target = Atol10.<>o__24.<>p__6.Target;
						CallSite <>p__ = Atol10.<>o__24.<>p__6;
						if (Atol10.<>o__24.<>p__5 == null)
						{
							Atol10.<>o__24.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamByteArray", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target2 = Atol10.<>o__24.<>p__5.Target;
						CallSite <>p__2 = Atol10.<>o__24.<>p__5;
						object atolDriver = this.AtolDriver;
						if (Atol10.<>o__24.<>p__4 == null)
						{
							Atol10.<>o__24.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TAG_VALUE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						byte[] clientInfo = target(<>p__, target2(<>p__2, atolDriver, Atol10.<>o__24.<>p__4.Target(Atol10.<>o__24.<>p__4, this.AtolDriver)));
						if (Atol10.<>o__24.<>p__7 == null)
						{
							Atol10.<>o__24.<>p__7 = CallSite<Action<CallSite, object, int, byte[]>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Atol10.<>o__24.<>p__7.Target(Atol10.<>o__24.<>p__7, this.AtolDriver, 1256, clientInfo);
					}
				}
				this.SendDigitalCheck(checkData.AddressForDigitalCheck);
			}
			object obj;
			switch (checkData.CheckType)
			{
			case CheckTypes.Sale:
				if (Atol10.<>o__24.<>p__8 == null)
				{
					Atol10.<>o__24.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_SELL", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj = Atol10.<>o__24.<>p__8.Target(Atol10.<>o__24.<>p__8, this.AtolDriver);
				break;
			case CheckTypes.ReturnSale:
				if (Atol10.<>o__24.<>p__9 == null)
				{
					Atol10.<>o__24.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_SELL_RETURN", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj = Atol10.<>o__24.<>p__9.Target(Atol10.<>o__24.<>p__9, this.AtolDriver);
				break;
			case CheckTypes.Buy:
				if (Atol10.<>o__24.<>p__10 == null)
				{
					Atol10.<>o__24.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_BUY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj = Atol10.<>o__24.<>p__10.Target(Atol10.<>o__24.<>p__10, this.AtolDriver);
				break;
			case CheckTypes.ReturnBuy:
				if (Atol10.<>o__24.<>p__11 == null)
				{
					Atol10.<>o__24.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_BUY_RETURN", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj = Atol10.<>o__24.<>p__11.Target(Atol10.<>o__24.<>p__11, this.AtolDriver);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			object checkType = obj;
			if (Atol10.<>o__24.<>p__13 == null)
			{
				Atol10.<>o__24.<>p__13 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target3 = Atol10.<>o__24.<>p__13.Target;
			CallSite <>p__3 = Atol10.<>o__24.<>p__13;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__24.<>p__12 == null)
			{
				Atol10.<>o__24.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target3(<>p__3, atolDriver2, Atol10.<>o__24.<>p__12.Target(Atol10.<>o__24.<>p__12, this.AtolDriver), checkType);
			if (this.DevicesConfig.CheckPrinter.FiscalKkm.IsAlwaysNoPrintCheck)
			{
				LogHelper.Debug("Выключаем печать бумажного чека АТОЛ");
				if (Atol10.<>o__24.<>p__15 == null)
				{
					Atol10.<>o__24.<>p__15 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, bool> target4 = Atol10.<>o__24.<>p__15.Target;
				CallSite <>p__4 = Atol10.<>o__24.<>p__15;
				object atolDriver3 = this.AtolDriver;
				if (Atol10.<>o__24.<>p__14 == null)
				{
					Atol10.<>o__24.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_ELECTRONICALLY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target4(<>p__4, atolDriver3, Atol10.<>o__24.<>p__14.Target(Atol10.<>o__24.<>p__14, this.AtolDriver), true);
			}
			if (Atol10.<>o__24.<>p__16 == null)
			{
				Atol10.<>o__24.<>p__16 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "openReceipt", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__24.<>p__16.Target(Atol10.<>o__24.<>p__16, this.AtolDriver);
			this.CheckResult();
			this.GetSalesNotice(checkData.TrueApiInfoForKkm);
			return true;
		}

		// Token: 0x06005400 RID: 21504 RVA: 0x001221C4 File Offset: 0x001203C4
		private void OperatorLogin(Cashier cashier)
		{
			Devices devices = new ConfigsRepository<Devices>().Get();
			this.WriteOfdAttribute(OfdAttributes.CashierName, cashier.Name);
			if (devices.CheckPrinter.FiscalKkm.FfdVersion > GlobalDictionaries.Devices.FfdVersions.Ffd100)
			{
				this.WriteOfdAttribute(OfdAttributes.CashierInn, cashier.Inn);
			}
			if (Atol10.<>o__25.<>p__0 == null)
			{
				Atol10.<>o__25.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "operatorLogin", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__25.<>p__0.Target(Atol10.<>o__25.<>p__0, this.AtolDriver);
			this.CheckResult();
		}

		// Token: 0x06005401 RID: 21505 RVA: 0x0012226C File Offset: 0x0012046C
		[HandleProcessCorruptedStateExceptions]
		private void Ffd120CodeValidation(CheckData checkData)
		{
			LogHelper.Debug("Начинаю валидацию КМ для ФФД 120, АТОЛ 10");
			try
			{
				if (!checkData.GoodsList.All(delegate(CheckGood x)
				{
					MarkedInfo markedInfo2 = x.MarkedInfo;
					return ((markedInfo2 != null) ? markedInfo2.Type : GlobalDictionaries.RuMarkedProductionTypes.None) == GlobalDictionaries.RuMarkedProductionTypes.None;
				}))
				{
					if (Atol10.<>o__26.<>p__0 == null)
					{
						Atol10.<>o__26.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "cancelMarkingCodeValidation", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Atol10.<>o__26.<>p__0.Target(Atol10.<>o__26.<>p__0, this.AtolDriver);
					if (Atol10.<>o__26.<>p__1 == null)
					{
						Atol10.<>o__26.<>p__1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "clearMarkingCodeValidationResult", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Atol10.<>o__26.<>p__1.Target(Atol10.<>o__26.<>p__1, this.AtolDriver);
					foreach (CheckGood item2 in checkData.GoodsList.Where((CheckGood item) => item.MarkedInfo != null && !item.MarkedInfo.FullCode.IsNullOrEmpty()))
					{
						item2.MarkedInfo.ValidationResultKkm = null;
						string fullCode = DataMatrixHelper.ReplaceSomeCharsToFNC1(item2.MarkedInfo.FullCode);
						int status = RuOnlineKkmHelper.GetMarkingCodeStatus(item2, checkData.CheckType);
						LogHelper.Debug("Валидация кода: " + fullCode);
						if (Atol10.<>o__26.<>p__4 == null)
						{
							Atol10.<>o__26.<>p__4 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Action<CallSite, object, object, object> target = Atol10.<>o__26.<>p__4.Target;
						CallSite <>p__ = Atol10.<>o__26.<>p__4;
						object atolDriver = this.AtolDriver;
						if (Atol10.<>o__26.<>p__2 == null)
						{
							Atol10.<>o__26.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj = Atol10.<>o__26.<>p__2.Target(Atol10.<>o__26.<>p__2, this.AtolDriver);
						if (Atol10.<>o__26.<>p__3 == null)
						{
							Atol10.<>o__26.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_MCT12_AUTO", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						target(<>p__, atolDriver, obj, Atol10.<>o__26.<>p__3.Target(Atol10.<>o__26.<>p__3, this.AtolDriver));
						if (Atol10.<>o__26.<>p__6 == null)
						{
							Atol10.<>o__26.<>p__6 = CallSite<Action<CallSite, object, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Action<CallSite, object, object, string> target2 = Atol10.<>o__26.<>p__6.Target;
						CallSite <>p__2 = Atol10.<>o__26.<>p__6;
						object atolDriver2 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__5 == null)
						{
							Atol10.<>o__26.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						target2(<>p__2, atolDriver2, Atol10.<>o__26.<>p__5.Target(Atol10.<>o__26.<>p__5, this.AtolDriver), fullCode);
						if (Atol10.<>o__26.<>p__8 == null)
						{
							Atol10.<>o__26.<>p__8 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Action<CallSite, object, object, int> target3 = Atol10.<>o__26.<>p__8.Target;
						CallSite <>p__3 = Atol10.<>o__26.<>p__8;
						object atolDriver3 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__7 == null)
						{
							Atol10.<>o__26.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						target3(<>p__3, atolDriver3, Atol10.<>o__26.<>p__7.Target(Atol10.<>o__26.<>p__7, this.AtolDriver), status);
						if (Atol10.<>o__26.<>p__10 == null)
						{
							Atol10.<>o__26.<>p__10 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Action<CallSite, object, object, bool> target4 = Atol10.<>o__26.<>p__10.Target;
						CallSite <>p__4 = Atol10.<>o__26.<>p__10;
						object atolDriver4 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__9 == null)
						{
							Atol10.<>o__26.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_WAIT_FOR_VALIDATION_RESULT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						target4(<>p__4, atolDriver4, Atol10.<>o__26.<>p__9.Target(Atol10.<>o__26.<>p__9, this.AtolDriver), true);
						if (Atol10.<>o__26.<>p__12 == null)
						{
							Atol10.<>o__26.<>p__12 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Action<CallSite, object, object, int> target5 = Atol10.<>o__26.<>p__12.Target;
						CallSite <>p__5 = Atol10.<>o__26.<>p__12;
						object atolDriver5 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__11 == null)
						{
							Atol10.<>o__26.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_PROCESSING_MODE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						target5(<>p__5, atolDriver5, Atol10.<>o__26.<>p__11.Target(Atol10.<>o__26.<>p__11, this.AtolDriver), 0);
						if (status.IsEither(new int[] { 2, 4 }))
						{
							if (Atol10.<>o__26.<>p__14 == null)
							{
								Atol10.<>o__26.<>p__14 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							Action<CallSite, object, object, double> target6 = Atol10.<>o__26.<>p__14.Target;
							CallSite <>p__6 = Atol10.<>o__26.<>p__14;
							object atolDriver6 = this.AtolDriver;
							if (Atol10.<>o__26.<>p__13 == null)
							{
								Atol10.<>o__26.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_QUANTITY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							target6(<>p__6, atolDriver6, Atol10.<>o__26.<>p__13.Target(Atol10.<>o__26.<>p__13, this.AtolDriver), (double)item2.Quantity);
							if (Atol10.<>o__26.<>p__16 == null)
							{
								Atol10.<>o__26.<>p__16 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							Action<CallSite, object, object, int> target7 = Atol10.<>o__26.<>p__16.Target;
							CallSite <>p__7 = Atol10.<>o__26.<>p__16;
							object atolDriver7 = this.AtolDriver;
							if (Atol10.<>o__26.<>p__15 == null)
							{
								Atol10.<>o__26.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MEASUREMENT_UNIT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							target7(<>p__7, atolDriver7, Atol10.<>o__26.<>p__15.Target(Atol10.<>o__26.<>p__15, this.AtolDriver), item2.Unit.RuFfdUnitsIndex);
							int ruFfdUnitsIndex = item2.Unit.RuFfdUnitsIndex;
						}
						if (Atol10.<>o__26.<>p__17 == null)
						{
							Atol10.<>o__26.<>p__17 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "beginMarkingCodeValidation", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Atol10.<>o__26.<>p__17.Target(Atol10.<>o__26.<>p__17, this.AtolDriver);
						bool validationReady = false;
						for (int i = 0; i < 30; i++)
						{
							LogHelper.Debug("Валидация кода продолэается, круг " + i.ToString());
							if (Atol10.<>o__26.<>p__18 == null)
							{
								Atol10.<>o__26.<>p__18 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "getMarkingCodeValidationStatus", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Atol10.<>o__26.<>p__18.Target(Atol10.<>o__26.<>p__18, this.AtolDriver);
							if (Atol10.<>o__26.<>p__21 == null)
							{
								Atol10.<>o__26.<>p__21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, bool> target8 = Atol10.<>o__26.<>p__21.Target;
							CallSite <>p__8 = Atol10.<>o__26.<>p__21;
							if (Atol10.<>o__26.<>p__20 == null)
							{
								Atol10.<>o__26.<>p__20 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamBool", null, typeof(Atol10), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target9 = Atol10.<>o__26.<>p__20.Target;
							CallSite <>p__9 = Atol10.<>o__26.<>p__20;
							object atolDriver8 = this.AtolDriver;
							if (Atol10.<>o__26.<>p__19 == null)
							{
								Atol10.<>o__26.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_VALIDATION_READY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							if (target8(<>p__8, target9(<>p__9, atolDriver8, Atol10.<>o__26.<>p__19.Target(Atol10.<>o__26.<>p__19, this.AtolDriver))))
							{
								validationReady = true;
								break;
							}
							Thread.Sleep(1000);
						}
						if (!validationReady)
						{
							item2.MarkedInfo.ValidationResultKkm = 0;
							LogHelper.Debug("Проверка кода не завершена, таймаут проверки, отменяем проверку, но проводим КМ в чек");
							if (Atol10.<>o__26.<>p__37 == null)
							{
								Atol10.<>o__26.<>p__37 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "acceptMarkingCode", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Atol10.<>o__26.<>p__37.Target(Atol10.<>o__26.<>p__37, this.AtolDriver);
							break;
						}
						if (Atol10.<>o__26.<>p__23 == null)
						{
							Atol10.<>o__26.<>p__23 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target10 = Atol10.<>o__26.<>p__23.Target;
						CallSite <>p__10 = Atol10.<>o__26.<>p__23;
						object atolDriver9 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__22 == null)
						{
							Atol10.<>o__26.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_ONLINE_VALIDATION_RESULT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object validationResult = target10(<>p__10, atolDriver9, Atol10.<>o__26.<>p__22.Target(Atol10.<>o__26.<>p__22, this.AtolDriver));
						if (Atol10.<>o__26.<>p__25 == null)
						{
							Atol10.<>o__26.<>p__25 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target11 = Atol10.<>o__26.<>p__25.Target;
						CallSite <>p__11 = Atol10.<>o__26.<>p__25;
						object atolDriver10 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__24 == null)
						{
							Atol10.<>o__26.<>p__24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_ONLINE_VALIDATION_ERROR", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object errorOnlineResult = target11(<>p__11, atolDriver10, Atol10.<>o__26.<>p__24.Target(Atol10.<>o__26.<>p__24, this.AtolDriver));
						if (Atol10.<>o__26.<>p__27 == null)
						{
							Atol10.<>o__26.<>p__27 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamString", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target12 = Atol10.<>o__26.<>p__27.Target;
						CallSite <>p__12 = Atol10.<>o__26.<>p__27;
						object atolDriver11 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__26 == null)
						{
							Atol10.<>o__26.<>p__26 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_ONLINE_VALIDATION_ERROR_DESCRIPTION", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object errorOnlineDescription = target12(<>p__12, atolDriver11, Atol10.<>o__26.<>p__26.Target(Atol10.<>o__26.<>p__26, this.AtolDriver));
						if (Atol10.<>o__26.<>p__29 == null)
						{
							Atol10.<>o__26.<>p__29 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target13 = Atol10.<>o__26.<>p__29.Target;
						CallSite <>p__13 = Atol10.<>o__26.<>p__29;
						object atolDriver12 = this.AtolDriver;
						if (Atol10.<>o__26.<>p__28 == null)
						{
							Atol10.<>o__26.<>p__28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_OFFLINE_VALIDATION_ERROR", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object errorOfflineResult = target13(<>p__13, atolDriver12, Atol10.<>o__26.<>p__28.Target(Atol10.<>o__26.<>p__28, this.AtolDriver));
						LogHelper.Debug("Проверка кода маркировки закончилась.");
						if (Atol10.<>o__26.<>p__33 == null)
						{
							Atol10.<>o__26.<>p__33 = CallSite<Action<CallSite, global::System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Debug", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Action<CallSite, Type, object> target14 = Atol10.<>o__26.<>p__33.Target;
						CallSite <>p__14 = Atol10.<>o__26.<>p__33;
						Type typeFromHandle = typeof(LogHelper);
						if (Atol10.<>o__26.<>p__32 == null)
						{
							Atol10.<>o__26.<>p__32 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target15 = Atol10.<>o__26.<>p__32.Target;
						CallSite <>p__15 = Atol10.<>o__26.<>p__32;
						if (Atol10.<>o__26.<>p__31 == null)
						{
							Atol10.<>o__26.<>p__31 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						Func<CallSite, object, string, object> target16 = Atol10.<>o__26.<>p__31.Target;
						CallSite <>p__16 = Atol10.<>o__26.<>p__31;
						if (Atol10.<>o__26.<>p__30 == null)
						{
							Atol10.<>o__26.<>p__30 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						target14(<>p__14, typeFromHandle, target15(<>p__15, target16(<>p__16, Atol10.<>o__26.<>p__30.Target(Atol10.<>o__26.<>p__30, "ErrorOnlineResult: ", errorOnlineResult), ", "), errorOnlineDescription));
						if (Atol10.<>o__26.<>p__35 == null)
						{
							Atol10.<>o__26.<>p__35 = CallSite<Action<CallSite, global::System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Debug", null, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Action<CallSite, Type, object> target17 = Atol10.<>o__26.<>p__35.Target;
						CallSite <>p__17 = Atol10.<>o__26.<>p__35;
						Type typeFromHandle2 = typeof(LogHelper);
						if (Atol10.<>o__26.<>p__34 == null)
						{
							Atol10.<>o__26.<>p__34 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof(Atol10), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						target17(<>p__17, typeFromHandle2, Atol10.<>o__26.<>p__34.Target(Atol10.<>o__26.<>p__34, "ErrorOfflineResult: ", errorOfflineResult));
						MarkedInfo markedInfo = item2.MarkedInfo;
						if (Atol10.<>o__26.<>p__36 == null)
						{
							Atol10.<>o__26.<>p__36 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
						}
						markedInfo.ValidationResultKkm = Atol10.<>o__26.<>p__36.Target(Atol10.<>o__26.<>p__36, validationResult);
						LogHelper.Debug(string.Format("Validation ready: {0}; result code: {1}", validationReady, item2.MarkedInfo.ValidationResultKkm));
						if (Atol10.<>o__26.<>p__38 == null)
						{
							Atol10.<>o__26.<>p__38 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "acceptMarkingCode", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Atol10.<>o__26.<>p__38.Target(Atol10.<>o__26.<>p__38, this.AtolDriver);
					}
				}
			}
			catch (Exception ex)
			{
				string message = Translate.Atol10_Ffd120CodeValidation_Ошибка_проверки_кода_маркировки_в_ККМ;
				LogHelper.WriteError(ex, message, true);
				LogHelper.ShowErrorMgs(ex, message, LogHelper.MsgTypes.Notification);
			}
		}

		// Token: 0x06005402 RID: 21506 RVA: 0x001231D8 File Offset: 0x001213D8
		public bool CloseCheck()
		{
			if (Atol10.<>o__27.<>p__0 == null)
			{
				Atol10.<>o__27.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "closeReceipt", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__27.<>p__0.Target(Atol10.<>o__27.<>p__0, this.AtolDriver);
			if (Atol10.<>o__27.<>p__1 == null)
			{
				Atol10.<>o__27.<>p__1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "checkDocumentClosed", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__27.<>p__1.Target(Atol10.<>o__27.<>p__1, this.AtolDriver);
			this.CheckResult();
			return true;
		}

		// Token: 0x06005403 RID: 21507 RVA: 0x00123298 File Offset: 0x00121498
		public void CancelCheck()
		{
			if (Atol10.<>o__28.<>p__0 == null)
			{
				Atol10.<>o__28.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "cancelReceipt", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__28.<>p__0.Target(Atol10.<>o__28.<>p__0, this.AtolDriver);
			this.CheckResult();
		}

		// Token: 0x06005404 RID: 21508 RVA: 0x00123300 File Offset: 0x00121500
		public bool CashOut(decimal sum, Cashier cashier)
		{
			if (Atol10.<>o__29.<>p__1 == null)
			{
				Atol10.<>o__29.<>p__1 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target = Atol10.<>o__29.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__29.<>p__1;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__29.<>p__0 == null)
			{
				Atol10.<>o__29.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, Atol10.<>o__29.<>p__0.Target(Atol10.<>o__29.<>p__0, this.AtolDriver), (double)sum);
			if (Atol10.<>o__29.<>p__2 == null)
			{
				Atol10.<>o__29.<>p__2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "cashOutcome", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__29.<>p__2.Target(Atol10.<>o__29.<>p__2, this.AtolDriver);
			this.CheckResult();
			return true;
		}

		// Token: 0x06005405 RID: 21509 RVA: 0x0012342C File Offset: 0x0012162C
		public bool CashIn(decimal sum, Cashier cashier)
		{
			if (Atol10.<>o__30.<>p__1 == null)
			{
				Atol10.<>o__30.<>p__1 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target = Atol10.<>o__30.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__30.<>p__1;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__30.<>p__0 == null)
			{
				Atol10.<>o__30.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, Atol10.<>o__30.<>p__0.Target(Atol10.<>o__30.<>p__0, this.AtolDriver), (double)sum);
			if (Atol10.<>o__30.<>p__2 == null)
			{
				Atol10.<>o__30.<>p__2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "cashIncome", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__30.<>p__2.Target(Atol10.<>o__30.<>p__2, this.AtolDriver);
			this.CheckResult();
			return true;
		}

		// Token: 0x06005406 RID: 21510 RVA: 0x00123555 File Offset: 0x00121755
		public bool WriteOfdAttribute(OfdAttributes ofdAttribute, object value)
		{
			this.WriteOfdAttribute((int)ofdAttribute, value);
			return true;
		}

		// Token: 0x06005407 RID: 21511 RVA: 0x00123560 File Offset: 0x00121760
		public bool GetCashSum(out decimal sum)
		{
			if (Atol10.<>o__32.<>p__2 == null)
			{
				Atol10.<>o__32.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__32.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__32.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__32.<>p__0 == null)
			{
				Atol10.<>o__32.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__32.<>p__0.Target(Atol10.<>o__32.<>p__0, this.AtolDriver);
			if (Atol10.<>o__32.<>p__1 == null)
			{
				Atol10.<>o__32.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_CASH_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__32.<>p__1.Target(Atol10.<>o__32.<>p__1, this.AtolDriver));
			if (Atol10.<>o__32.<>p__3 == null)
			{
				Atol10.<>o__32.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__32.<>p__3.Target(Atol10.<>o__32.<>p__3, this.AtolDriver);
			this.CheckResult();
			if (Atol10.<>o__32.<>p__6 == null)
			{
				Atol10.<>o__32.<>p__6 = CallSite<Func<CallSite, object, decimal>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(decimal), typeof(Atol10)));
			}
			Func<CallSite, object, decimal> target2 = Atol10.<>o__32.<>p__6.Target;
			CallSite <>p__2 = Atol10.<>o__32.<>p__6;
			if (Atol10.<>o__32.<>p__5 == null)
			{
				Atol10.<>o__32.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamDouble", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target3 = Atol10.<>o__32.<>p__5.Target;
			CallSite <>p__3 = Atol10.<>o__32.<>p__5;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__32.<>p__4 == null)
			{
				Atol10.<>o__32.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			sum = target2(<>p__2, target3(<>p__3, atolDriver2, Atol10.<>o__32.<>p__4.Target(Atol10.<>o__32.<>p__4, this.AtolDriver)));
			return true;
		}

		// Token: 0x06005408 RID: 21512 RVA: 0x001237C4 File Offset: 0x001219C4
		public bool RegisterGood(CheckGood good, CheckTypes checkType)
		{
			LogHelper.Debug("АТОЛ 10: 100");
			if (Atol10.<>o__33.<>p__2 == null)
			{
				Atol10.<>o__33.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__33.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__33.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__33.<>p__0 == null)
			{
				Atol10.<>o__33.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TAX_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__33.<>p__0.Target(Atol10.<>o__33.<>p__0, this.AtolDriver);
			if (Atol10.<>o__33.<>p__1 == null)
			{
				Atol10.<>o__33.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_NO", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__33.<>p__1.Target(Atol10.<>o__33.<>p__1, this.AtolDriver));
			if (Atol10.<>o__33.<>p__4 == null)
			{
				Atol10.<>o__33.<>p__4 = CallSite<Action<CallSite, object, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, string> target2 = Atol10.<>o__33.<>p__4.Target;
			CallSite <>p__2 = Atol10.<>o__33.<>p__4;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__3 == null)
			{
				Atol10.<>o__33.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_COMMODITY_NAME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target2(<>p__2, atolDriver2, Atol10.<>o__33.<>p__3.Target(Atol10.<>o__33.<>p__3, this.AtolDriver), good.Name);
			if (Atol10.<>o__33.<>p__6 == null)
			{
				Atol10.<>o__33.<>p__6 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target3 = Atol10.<>o__33.<>p__6.Target;
			CallSite <>p__3 = Atol10.<>o__33.<>p__6;
			object atolDriver3 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__5 == null)
			{
				Atol10.<>o__33.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PRICE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target3(<>p__3, atolDriver3, Atol10.<>o__33.<>p__5.Target(Atol10.<>o__33.<>p__5, this.AtolDriver), (double)good.Price);
			if (Atol10.<>o__33.<>p__8 == null)
			{
				Atol10.<>o__33.<>p__8 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target4 = Atol10.<>o__33.<>p__8.Target;
			CallSite <>p__4 = Atol10.<>o__33.<>p__8;
			object atolDriver4 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__7 == null)
			{
				Atol10.<>o__33.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_QUANTITY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target4(<>p__4, atolDriver4, Atol10.<>o__33.<>p__7.Target(Atol10.<>o__33.<>p__7, this.AtolDriver), (double)good.Quantity);
			if (Atol10.<>o__33.<>p__10 == null)
			{
				Atol10.<>o__33.<>p__10 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, int> target5 = Atol10.<>o__33.<>p__10.Target;
			CallSite <>p__5 = Atol10.<>o__33.<>p__10;
			object atolDriver5 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__9 == null)
			{
				Atol10.<>o__33.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DEPARTMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target5(<>p__5, atolDriver5, Atol10.<>o__33.<>p__9.Target(Atol10.<>o__33.<>p__9, this.AtolDriver), good.KkmSectionNumber);
			if (Atol10.<>o__33.<>p__12 == null)
			{
				Atol10.<>o__33.<>p__12 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target6 = Atol10.<>o__33.<>p__12.Target;
			CallSite <>p__6 = Atol10.<>o__33.<>p__12;
			object atolDriver6 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__11 == null)
			{
				Atol10.<>o__33.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_INFO_DISCOUNT_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target6(<>p__6, atolDriver6, Atol10.<>o__33.<>p__11.Target(Atol10.<>o__33.<>p__11, this.AtolDriver), (double)good.DiscountSum);
			object obj2;
			switch (good.TaxRateNumber)
			{
			case 1:
				if (Atol10.<>o__33.<>p__13 == null)
				{
					Atol10.<>o__33.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_NO", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__13.Target(Atol10.<>o__33.<>p__13, this.AtolDriver);
				break;
			case 2:
				if (Atol10.<>o__33.<>p__14 == null)
				{
					Atol10.<>o__33.<>p__14 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT0", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__14.Target(Atol10.<>o__33.<>p__14, this.AtolDriver);
				break;
			case 3:
				if (Atol10.<>o__33.<>p__15 == null)
				{
					Atol10.<>o__33.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT10", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__15.Target(Atol10.<>o__33.<>p__15, this.AtolDriver);
				break;
			case 4:
				if (Atol10.<>o__33.<>p__16 == null)
				{
					Atol10.<>o__33.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT20", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__16.Target(Atol10.<>o__33.<>p__16, this.AtolDriver);
				break;
			case 5:
				if (Atol10.<>o__33.<>p__17 == null)
				{
					Atol10.<>o__33.<>p__17 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT110", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__17.Target(Atol10.<>o__33.<>p__17, this.AtolDriver);
				break;
			case 6:
				if (Atol10.<>o__33.<>p__18 == null)
				{
					Atol10.<>o__33.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT120", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__18.Target(Atol10.<>o__33.<>p__18, this.AtolDriver);
				break;
			case 7:
				if (Atol10.<>o__33.<>p__19 == null)
				{
					Atol10.<>o__33.<>p__19 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT5", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__19.Target(Atol10.<>o__33.<>p__19, this.AtolDriver);
				break;
			case 8:
				if (Atol10.<>o__33.<>p__20 == null)
				{
					Atol10.<>o__33.<>p__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT7", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__20.Target(Atol10.<>o__33.<>p__20, this.AtolDriver);
				break;
			case 9:
				if (Atol10.<>o__33.<>p__21 == null)
				{
					Atol10.<>o__33.<>p__21 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT105", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__21.Target(Atol10.<>o__33.<>p__21, this.AtolDriver);
				break;
			case 10:
				if (Atol10.<>o__33.<>p__22 == null)
				{
					Atol10.<>o__33.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_VAT107", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__22.Target(Atol10.<>o__33.<>p__22, this.AtolDriver);
				break;
			default:
				if (Atol10.<>o__33.<>p__23 == null)
				{
					Atol10.<>o__33.<>p__23 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_TAX_NO", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				obj2 = Atol10.<>o__33.<>p__23.Target(Atol10.<>o__33.<>p__23, this.AtolDriver);
				break;
			}
			object driverTaxValue = obj2;
			LogHelper.Debug("АТОЛ 10: 110");
			if (Atol10.<>o__33.<>p__25 == null)
			{
				Atol10.<>o__33.<>p__25 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target7 = Atol10.<>o__33.<>p__25.Target;
			CallSite <>p__7 = Atol10.<>o__33.<>p__25;
			object atolDriver7 = this.AtolDriver;
			if (Atol10.<>o__33.<>p__24 == null)
			{
				Atol10.<>o__33.<>p__24 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TAX_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target7(<>p__7, atolDriver7, Atol10.<>o__33.<>p__24.Target(Atol10.<>o__33.<>p__24, this.AtolDriver), driverTaxValue);
			Devices dc = new ConfigsRepository<Devices>().Get();
			GlobalDictionaries.RuFfdGoodsTypes typeGoodOfd = ((good.RuFfdGoodTypeCode == GlobalDictionaries.RuFfdGoodsTypes.None) ? GlobalDictionaries.RuFfdGoodsTypes.SimpleGood : good.RuFfdGoodTypeCode);
			LogHelper.Debug("АТОЛ 10: 120");
			if (Atol10.<>o__33.<>p__26 == null)
			{
				Atol10.<>o__33.<>p__26 = CallSite<Action<CallSite, object, int, GlobalDictionaries.RuFfdGoodsTypes>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Atol10.<>o__33.<>p__26.Target(Atol10.<>o__33.<>p__26, this.AtolDriver, 1212, typeGoodOfd);
			if (Atol10.<>o__33.<>p__27 == null)
			{
				Atol10.<>o__33.<>p__27 = CallSite<Action<CallSite, object, int, GlobalDictionaries.RuFfdPaymentModes>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Atol10.<>o__33.<>p__27.Target(Atol10.<>o__33.<>p__27, this.AtolDriver, 1214, good.RuFfdPaymentModeCode);
			switch (dc.CheckPrinter.FiscalKkm.FfdVersion)
			{
			case GlobalDictionaries.Devices.FfdVersions.OfflineKkm:
			case GlobalDictionaries.Devices.FfdVersions.Ffd100:
				break;
			case GlobalDictionaries.Devices.FfdVersions.Ffd105:
			case GlobalDictionaries.Devices.FfdVersions.Ffd110:
				this.SetInfo_ffd105_ffd110(good);
				break;
			case GlobalDictionaries.Devices.FfdVersions.Ffd120:
				this.SetInfo_ffd120(good);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			LogHelper.Debug("АТОЛ 10: 130");
			try
			{
				if (Atol10.<>o__33.<>p__28 == null)
				{
					Atol10.<>o__33.<>p__28 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "registration", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__33.<>p__28.Target(Atol10.<>o__33.<>p__28, this.AtolDriver);
			}
			catch (Exception ex)
			{
				LogHelper.Error(ex, "ОШИБКА РЕГИСТРАЦИИ АТОЛ", false, true, true);
				throw new KkmException(this, "ОШИБКА РЕГИСТРАЦИИ АТОЛ", KkmException.ErrorTypes.Unknown);
			}
			LogHelper.Debug("АТОЛ 10: 140");
			this.CheckResult();
			this.PrintNonFiscalStrings(good.CommentForFiscalCheck.Select((string x) => new NonFiscalString(x)).ToList<NonFiscalString>(), false);
			return true;
		}

		// Token: 0x06005409 RID: 21513 RVA: 0x00124384 File Offset: 0x00122584
		private void SetInfo_ffd120(CheckGood good)
		{
			LogHelper.Debug(string.Format("Запись тега 2108: {0}", good.Unit.RuFfdUnitsIndex));
			if (Atol10.<>o__34.<>p__1 == null)
			{
				Atol10.<>o__34.<>p__1 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, int> target = Atol10.<>o__34.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__34.<>p__1;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__34.<>p__0 == null)
			{
				Atol10.<>o__34.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MEASUREMENT_UNIT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, Atol10.<>o__34.<>p__0.Target(Atol10.<>o__34.<>p__0, this.AtolDriver), good.Unit.RuFfdUnitsIndex);
			MarkedInfo markedInfo = good.MarkedInfo;
			string fullCode = this.PrepareMarkCodeForFfd120(((markedInfo != null) ? markedInfo.FullCode : null) ?? string.Empty);
			if (good.MarkedInfo != null && !fullCode.IsNullOrEmpty())
			{
				if (this._industryInfo != null)
				{
					if (Atol10.<>o__34.<>p__2 == null)
					{
						Atol10.<>o__34.<>p__2 = CallSite<Action<CallSite, object, int, byte[]>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Atol10.<>o__34.<>p__2.Target(Atol10.<>o__34.<>p__2, this.AtolDriver, 1260, this._industryInfo);
				}
				LogHelper.Debug(string.Format("Запись тега 2106: {0}", good.MarkedInfo.ValidationResultKkm));
				if (Atol10.<>o__34.<>p__4 == null)
				{
					Atol10.<>o__34.<>p__4 = CallSite<Action<CallSite, object, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, string> target2 = Atol10.<>o__34.<>p__4.Target;
				CallSite <>p__2 = Atol10.<>o__34.<>p__4;
				object atolDriver2 = this.AtolDriver;
				if (Atol10.<>o__34.<>p__3 == null)
				{
					Atol10.<>o__34.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(<>p__2, atolDriver2, Atol10.<>o__34.<>p__3.Target(Atol10.<>o__34.<>p__3, this.AtolDriver), fullCode);
				if (Atol10.<>o__34.<>p__6 == null)
				{
					Atol10.<>o__34.<>p__6 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, int> target3 = Atol10.<>o__34.<>p__6.Target;
				CallSite <>p__3 = Atol10.<>o__34.<>p__6;
				object atolDriver3 = this.AtolDriver;
				if (Atol10.<>o__34.<>p__5 == null)
				{
					Atol10.<>o__34.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target3(<>p__3, atolDriver3, Atol10.<>o__34.<>p__5.Target(Atol10.<>o__34.<>p__5, this.AtolDriver), RuOnlineKkmHelper.GetMarkingCodeStatus(good, this._checkData.CheckType));
				if (Atol10.<>o__34.<>p__8 == null)
				{
					Atol10.<>o__34.<>p__8 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, int> target4 = Atol10.<>o__34.<>p__8.Target;
				CallSite <>p__4 = Atol10.<>o__34.<>p__8;
				object atolDriver4 = this.AtolDriver;
				if (Atol10.<>o__34.<>p__7 == null)
				{
					Atol10.<>o__34.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_PROCESSING_MODE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target4(<>p__4, atolDriver4, Atol10.<>o__34.<>p__7.Target(Atol10.<>o__34.<>p__7, this.AtolDriver), 0);
				if (Atol10.<>o__34.<>p__11 == null)
				{
					Atol10.<>o__34.<>p__11 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target5 = Atol10.<>o__34.<>p__11.Target;
				CallSite <>p__5 = Atol10.<>o__34.<>p__11;
				object atolDriver5 = this.AtolDriver;
				if (Atol10.<>o__34.<>p__9 == null)
				{
					Atol10.<>o__34.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj = Atol10.<>o__34.<>p__9.Target(Atol10.<>o__34.<>p__9, this.AtolDriver);
				if (Atol10.<>o__34.<>p__10 == null)
				{
					Atol10.<>o__34.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_MCT12_AUTO", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target5(<>p__5, atolDriver5, obj, Atol10.<>o__34.<>p__10.Target(Atol10.<>o__34.<>p__10, this.AtolDriver));
				if (Atol10.<>o__34.<>p__13 == null)
				{
					Atol10.<>o__34.<>p__13 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, object> target6 = Atol10.<>o__34.<>p__13.Target;
				CallSite <>p__6 = Atol10.<>o__34.<>p__13;
				object atolDriver6 = this.AtolDriver;
				if (Atol10.<>o__34.<>p__12 == null)
				{
					Atol10.<>o__34.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MARKING_CODE_ONLINE_VALIDATION_RESULT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target6(<>p__6, atolDriver6, Atol10.<>o__34.<>p__12.Target(Atol10.<>o__34.<>p__12, this.AtolDriver), good.MarkedInfo.ValidationResultKkm ?? 0);
			}
		}

		// Token: 0x0600540A RID: 21514 RVA: 0x00124958 File Offset: 0x00122B58
		private void SetInfo_ffd105_ffd110(CheckGood good)
		{
			if (good.MarkedInfo != null && good.MarkedInfo.Type != GlobalDictionaries.RuMarkedProductionTypes.None && good.MarkedInfo.IsValidCode())
			{
				LogHelper.Debug("Маркировка " + good.MarkedInfo.ToJsonString(false, false));
				string ma = good.MarkedInfo.GetHexStringAttribute();
				LogHelper.Debug("Маркировка " + ma);
				if (!ma.IsNullOrEmpty())
				{
					LogHelper.Debug("Запись тега 1162: " + ma);
					if (Atol10.<>o__35.<>p__0 == null)
					{
						Atol10.<>o__35.<>p__0 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParamStrHex", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					Atol10.<>o__35.<>p__0.Target(Atol10.<>o__35.<>p__0, this.AtolDriver, 1162, ma);
				}
			}
		}

		// Token: 0x0600540B RID: 21515 RVA: 0x00124A50 File Offset: 0x00122C50
		public bool RegisterPayment(CheckPayment payment)
		{
			switch (payment.Method)
			{
			case GlobalDictionaries.KkmPaymentMethods.Cash:
			{
				if (Atol10.<>o__36.<>p__2 == null)
				{
					Atol10.<>o__36.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target = Atol10.<>o__36.<>p__2.Target;
				CallSite <>p__ = Atol10.<>o__36.<>p__2;
				object atolDriver = this.AtolDriver;
				if (Atol10.<>o__36.<>p__0 == null)
				{
					Atol10.<>o__36.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj = Atol10.<>o__36.<>p__0.Target(Atol10.<>o__36.<>p__0, this.AtolDriver);
				if (Atol10.<>o__36.<>p__1 == null)
				{
					Atol10.<>o__36.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PT_CASH", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target(<>p__, atolDriver, obj, Atol10.<>o__36.<>p__1.Target(Atol10.<>o__36.<>p__1, this.AtolDriver));
				break;
			}
			case GlobalDictionaries.KkmPaymentMethods.Card:
			case GlobalDictionaries.KkmPaymentMethods.EMoney:
			{
				if (Atol10.<>o__36.<>p__5 == null)
				{
					Atol10.<>o__36.<>p__5 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target2 = Atol10.<>o__36.<>p__5.Target;
				CallSite <>p__2 = Atol10.<>o__36.<>p__5;
				object atolDriver2 = this.AtolDriver;
				if (Atol10.<>o__36.<>p__3 == null)
				{
					Atol10.<>o__36.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = Atol10.<>o__36.<>p__3.Target(Atol10.<>o__36.<>p__3, this.AtolDriver);
				if (Atol10.<>o__36.<>p__4 == null)
				{
					Atol10.<>o__36.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PT_ELECTRONICALLY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(<>p__2, atolDriver2, obj2, Atol10.<>o__36.<>p__4.Target(Atol10.<>o__36.<>p__4, this.AtolDriver));
				break;
			}
			case GlobalDictionaries.KkmPaymentMethods.Bank:
			{
				if (Atol10.<>o__36.<>p__8 == null)
				{
					Atol10.<>o__36.<>p__8 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target3 = Atol10.<>o__36.<>p__8.Target;
				CallSite <>p__3 = Atol10.<>o__36.<>p__8;
				object atolDriver3 = this.AtolDriver;
				if (Atol10.<>o__36.<>p__6 == null)
				{
					Atol10.<>o__36.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj3 = Atol10.<>o__36.<>p__6.Target(Atol10.<>o__36.<>p__6, this.AtolDriver);
				if (Atol10.<>o__36.<>p__7 == null)
				{
					Atol10.<>o__36.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PT_6", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target3(<>p__3, atolDriver3, obj3, Atol10.<>o__36.<>p__7.Target(Atol10.<>o__36.<>p__7, this.AtolDriver));
				break;
			}
			case GlobalDictionaries.KkmPaymentMethods.Bonus:
			case GlobalDictionaries.KkmPaymentMethods.Certificate:
				return true;
			case GlobalDictionaries.KkmPaymentMethods.Credit:
			{
				if (Atol10.<>o__36.<>p__11 == null)
				{
					Atol10.<>o__36.<>p__11 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target4 = Atol10.<>o__36.<>p__11.Target;
				CallSite <>p__4 = Atol10.<>o__36.<>p__11;
				object atolDriver4 = this.AtolDriver;
				if (Atol10.<>o__36.<>p__9 == null)
				{
					Atol10.<>o__36.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj4 = Atol10.<>o__36.<>p__9.Target(Atol10.<>o__36.<>p__9, this.AtolDriver);
				if (Atol10.<>o__36.<>p__10 == null)
				{
					Atol10.<>o__36.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PT_CREDIT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target4(<>p__4, atolDriver4, obj4, Atol10.<>o__36.<>p__10.Target(Atol10.<>o__36.<>p__10, this.AtolDriver));
				break;
			}
			case GlobalDictionaries.KkmPaymentMethods.PrePayment:
			{
				if (Atol10.<>o__36.<>p__14 == null)
				{
					Atol10.<>o__36.<>p__14 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target5 = Atol10.<>o__36.<>p__14.Target;
				CallSite <>p__5 = Atol10.<>o__36.<>p__14;
				object atolDriver5 = this.AtolDriver;
				if (Atol10.<>o__36.<>p__12 == null)
				{
					Atol10.<>o__36.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj5 = Atol10.<>o__36.<>p__12.Target(Atol10.<>o__36.<>p__12, this.AtolDriver);
				if (Atol10.<>o__36.<>p__13 == null)
				{
					Atol10.<>o__36.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PT_PREPAID", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target5(<>p__5, atolDriver5, obj5, Atol10.<>o__36.<>p__13.Target(Atol10.<>o__36.<>p__13, this.AtolDriver));
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (Atol10.<>o__36.<>p__16 == null)
			{
				Atol10.<>o__36.<>p__16 = CallSite<Action<CallSite, object, object, double>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, double> target6 = Atol10.<>o__36.<>p__16.Target;
			CallSite <>p__6 = Atol10.<>o__36.<>p__16;
			object atolDriver6 = this.AtolDriver;
			if (Atol10.<>o__36.<>p__15 == null)
			{
				Atol10.<>o__36.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PAYMENT_SUM", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target6(<>p__6, atolDriver6, Atol10.<>o__36.<>p__15.Target(Atol10.<>o__36.<>p__15, this.AtolDriver), (double)payment.Sum);
			if (Atol10.<>o__36.<>p__17 == null)
			{
				Atol10.<>o__36.<>p__17 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "payment", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__36.<>p__17.Target(Atol10.<>o__36.<>p__17, this.AtolDriver);
			this.CheckResult();
			return true;
		}

		// Token: 0x0600540C RID: 21516 RVA: 0x001250FB File Offset: 0x001232FB
		public bool RegisterCheckDiscount(decimal sum, string description)
		{
			this.PrintNonFiscalStrings(new List<NonFiscalString>
			{
				new NonFiscalString(string.Format("{0}: {1:N2}", description, sum), TextAlignment.Right)
			}, false);
			return true;
		}

		// Token: 0x0600540D RID: 21517 RVA: 0x00125128 File Offset: 0x00123328
		public void Connect(bool onlyDriverLoad = false, Devices dc = null)
		{
			LogHelper.Debug("Подключение к ККМ АТОЛ 10");
			this.AtolDriver = Functions.CreateObject("AddIn.Fptr10");
			if (Atol10.<>o__38.<>p__1 == null)
			{
				Atol10.<>o__38.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = Atol10.<>o__38.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__38.<>p__1;
			if (Atol10.<>o__38.<>p__0 == null)
			{
				Atol10.<>o__38.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			if (target(<>p__, Atol10.<>o__38.<>p__0.Target(Atol10.<>o__38.<>p__0, this.AtolDriver, null)))
			{
				throw new NullReferenceException(Translate.Atol10_Объект_драйвера_АТОЛ_10_не_был_создан);
			}
			string s = this.DevicesConfig.CheckPrinter.FiscalKkm.Atol10ConnectionConfig;
			if (!s.IsNullOrEmpty())
			{
				if (Atol10.<>o__38.<>p__2 == null)
				{
					Atol10.<>o__38.<>p__2 = CallSite<Action<CallSite, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setSettings", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Atol10.<>o__38.<>p__2.Target(Atol10.<>o__38.<>p__2, this.AtolDriver, s);
			}
			if (onlyDriverLoad)
			{
				return;
			}
			if (Atol10.<>o__38.<>p__3 == null)
			{
				Atol10.<>o__38.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "open", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__38.<>p__3.Target(Atol10.<>o__38.<>p__3, this.AtolDriver);
			this.CheckResult();
		}

		// Token: 0x0600540E RID: 21518 RVA: 0x001252D8 File Offset: 0x001234D8
		public bool Disconnect()
		{
			if (Atol10.<>o__39.<>p__1 == null)
			{
				Atol10.<>o__39.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = Atol10.<>o__39.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__39.<>p__1;
			if (Atol10.<>o__39.<>p__0 == null)
			{
				Atol10.<>o__39.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			if (target(<>p__, Atol10.<>o__39.<>p__0.Target(Atol10.<>o__39.<>p__0, this.AtolDriver, null)))
			{
				return true;
			}
			if (Atol10.<>o__39.<>p__2 == null)
			{
				Atol10.<>o__39.<>p__2 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "close", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__39.<>p__2.Target(Atol10.<>o__39.<>p__2, this.AtolDriver);
			this.CheckResult();
			if (Atol10.<>o__39.<>p__3 == null)
			{
				Atol10.<>o__39.<>p__3 = CallSite<Action<CallSite, global::System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ReleaseComObject", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Atol10.<>o__39.<>p__3.Target(Atol10.<>o__39.<>p__3, typeof(Marshal), this.AtolDriver);
			this.AtolDriver = null;
			return true;
		}

		// Token: 0x1700275F RID: 10079
		// (get) Token: 0x0600540F RID: 21519 RVA: 0x00125458 File Offset: 0x00123658
		// (set) Token: 0x06005410 RID: 21520 RVA: 0x00125598 File Offset: 0x00123798
		public bool IsConnected
		{
			get
			{
				if (Atol10.<>o__41.<>p__1 == null)
				{
					Atol10.<>o__41.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target = Atol10.<>o__41.<>p__1.Target;
				CallSite <>p__ = Atol10.<>o__41.<>p__1;
				if (Atol10.<>o__41.<>p__0 == null)
				{
					Atol10.<>o__41.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				if (target(<>p__, Atol10.<>o__41.<>p__0.Target(Atol10.<>o__41.<>p__0, this.AtolDriver, null)))
				{
					return false;
				}
				if (Atol10.<>o__41.<>p__3 == null)
				{
					Atol10.<>o__41.<>p__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(bool), typeof(Atol10)));
				}
				Func<CallSite, object, bool> target2 = Atol10.<>o__41.<>p__3.Target;
				CallSite <>p__2 = Atol10.<>o__41.<>p__3;
				if (Atol10.<>o__41.<>p__2 == null)
				{
					Atol10.<>o__41.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "isOpened", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				return target2(<>p__2, Atol10.<>o__41.<>p__2.Target(Atol10.<>o__41.<>p__2, this.AtolDriver));
			}
			set
			{
			}
		}

		// Token: 0x06005411 RID: 21521 RVA: 0x0012559C File Offset: 0x0012379C
		public void PrintNonFiscalStrings(List<NonFiscalString> nonFiscalStrings, bool isOpenCheck)
		{
			if (isOpenCheck)
			{
				if (Atol10.<>o__43.<>p__0 == null)
				{
					Atol10.<>o__43.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "beginNonfiscalDocument", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__43.<>p__0.Target(Atol10.<>o__43.<>p__0, this.AtolDriver);
			}
			foreach (NonFiscalString nonFiscalString in nonFiscalStrings)
			{
				if (Atol10.<>o__43.<>p__2 == null)
				{
					Atol10.<>o__43.<>p__2 = CallSite<Action<CallSite, object, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, string> target = Atol10.<>o__43.<>p__2.Target;
				CallSite <>p__ = Atol10.<>o__43.<>p__2;
				object atolDriver = this.AtolDriver;
				if (Atol10.<>o__43.<>p__1 == null)
				{
					Atol10.<>o__43.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TEXT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target(<>p__, atolDriver, Atol10.<>o__43.<>p__1.Target(Atol10.<>o__43.<>p__1, this.AtolDriver), nonFiscalString.Text);
				if (Atol10.<>o__43.<>p__4 == null)
				{
					Atol10.<>o__43.<>p__4 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, bool> target2 = Atol10.<>o__43.<>p__4.Target;
				CallSite <>p__2 = Atol10.<>o__43.<>p__4;
				object atolDriver2 = this.AtolDriver;
				if (Atol10.<>o__43.<>p__3 == null)
				{
					Atol10.<>o__43.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FONT_DOUBLE_WIDTH", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(<>p__2, atolDriver2, Atol10.<>o__43.<>p__3.Target(Atol10.<>o__43.<>p__3, this.AtolDriver), nonFiscalString.WideFont);
				if (Atol10.<>o__43.<>p__6 == null)
				{
					Atol10.<>o__43.<>p__6 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				Action<CallSite, object, object, bool> target3 = Atol10.<>o__43.<>p__6.Target;
				CallSite <>p__3 = Atol10.<>o__43.<>p__6;
				object atolDriver3 = this.AtolDriver;
				if (Atol10.<>o__43.<>p__5 == null)
				{
					Atol10.<>o__43.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FONT_DOUBLE_HEIGHT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target3(<>p__3, atolDriver3, Atol10.<>o__43.<>p__5.Target(Atol10.<>o__43.<>p__5, this.AtolDriver), nonFiscalString.WideFont);
				if (Atol10.<>o__43.<>p__8 == null)
				{
					Atol10.<>o__43.<>p__8 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, int> target4 = Atol10.<>o__43.<>p__8.Target;
				CallSite <>p__4 = Atol10.<>o__43.<>p__8;
				object atolDriver4 = this.AtolDriver;
				if (Atol10.<>o__43.<>p__7 == null)
				{
					Atol10.<>o__43.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TEXT_WRAP", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target4(<>p__4, atolDriver4, Atol10.<>o__43.<>p__7.Target(Atol10.<>o__43.<>p__7, this.AtolDriver), 1);
				switch (nonFiscalString.Alignment)
				{
				case TextAlignment.Left:
				{
					if (Atol10.<>o__43.<>p__10 == null)
					{
						Atol10.<>o__43.<>p__10 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, object, int> target5 = Atol10.<>o__43.<>p__10.Target;
					CallSite <>p__5 = Atol10.<>o__43.<>p__10;
					object atolDriver5 = this.AtolDriver;
					if (Atol10.<>o__43.<>p__9 == null)
					{
						Atol10.<>o__43.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_ALIGNMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					target5(<>p__5, atolDriver5, Atol10.<>o__43.<>p__9.Target(Atol10.<>o__43.<>p__9, this.AtolDriver), 0);
					break;
				}
				case TextAlignment.Right:
				{
					if (Atol10.<>o__43.<>p__12 == null)
					{
						Atol10.<>o__43.<>p__12 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, object, int> target6 = Atol10.<>o__43.<>p__12.Target;
					CallSite <>p__6 = Atol10.<>o__43.<>p__12;
					object atolDriver6 = this.AtolDriver;
					if (Atol10.<>o__43.<>p__11 == null)
					{
						Atol10.<>o__43.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_ALIGNMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					target6(<>p__6, atolDriver6, Atol10.<>o__43.<>p__11.Target(Atol10.<>o__43.<>p__11, this.AtolDriver), 2);
					break;
				}
				case TextAlignment.Center:
				{
					if (Atol10.<>o__43.<>p__14 == null)
					{
						Atol10.<>o__43.<>p__14 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, object, int> target7 = Atol10.<>o__43.<>p__14.Target;
					CallSite <>p__7 = Atol10.<>o__43.<>p__14;
					object atolDriver7 = this.AtolDriver;
					if (Atol10.<>o__43.<>p__13 == null)
					{
						Atol10.<>o__43.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_ALIGNMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					target7(<>p__7, atolDriver7, Atol10.<>o__43.<>p__13.Target(Atol10.<>o__43.<>p__13, this.AtolDriver), 1);
					break;
				}
				default:
				{
					if (Atol10.<>o__43.<>p__16 == null)
					{
						Atol10.<>o__43.<>p__16 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					Action<CallSite, object, object, int> target8 = Atol10.<>o__43.<>p__16.Target;
					CallSite <>p__8 = Atol10.<>o__43.<>p__16;
					object atolDriver8 = this.AtolDriver;
					if (Atol10.<>o__43.<>p__15 == null)
					{
						Atol10.<>o__43.<>p__15 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_ALIGNMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					target8(<>p__8, atolDriver8, Atol10.<>o__43.<>p__15.Target(Atol10.<>o__43.<>p__15, this.AtolDriver), 0);
					break;
				}
				}
				if (Atol10.<>o__43.<>p__17 == null)
				{
					Atol10.<>o__43.<>p__17 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "printText", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__43.<>p__17.Target(Atol10.<>o__43.<>p__17, this.AtolDriver);
				this.CheckResult();
			}
			if (isOpenCheck)
			{
				if (Atol10.<>o__43.<>p__19 == null)
				{
					Atol10.<>o__43.<>p__19 = CallSite<Action<CallSite, object, object, bool>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, bool> target9 = Atol10.<>o__43.<>p__19.Target;
				CallSite <>p__9 = Atol10.<>o__43.<>p__19;
				object atolDriver9 = this.AtolDriver;
				if (Atol10.<>o__43.<>p__18 == null)
				{
					Atol10.<>o__43.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_PRINT_FOOTER", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target9(<>p__9, atolDriver9, Atol10.<>o__43.<>p__18.Target(Atol10.<>o__43.<>p__18, this.AtolDriver), false);
				if (Atol10.<>o__43.<>p__20 == null)
				{
					Atol10.<>o__43.<>p__20 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "endNonfiscalDocument", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__43.<>p__20.Target(Atol10.<>o__43.<>p__20, this.AtolDriver);
			}
		}

		// Token: 0x06005412 RID: 21522 RVA: 0x00125DCC File Offset: 0x00123FCC
		public void PrintNonFiscalStrings(List<NonFiscalString> nonFiscalStrings)
		{
			this.PrintNonFiscalStrings(nonFiscalStrings, true);
		}

		// Token: 0x06005413 RID: 21523 RVA: 0x00125DD8 File Offset: 0x00123FD8
		public bool PrintBarcode(string code, BarcodeTypes type)
		{
			if (Atol10.<>o__45.<>p__1 == null)
			{
				Atol10.<>o__45.<>p__1 = CallSite<Action<CallSite, object, object, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Action<CallSite, object, object, string> target = Atol10.<>o__45.<>p__1.Target;
			CallSite <>p__ = Atol10.<>o__45.<>p__1;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__45.<>p__0 == null)
			{
				Atol10.<>o__45.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_BARCODE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, Atol10.<>o__45.<>p__0.Target(Atol10.<>o__45.<>p__0, this.AtolDriver), code);
			switch (type)
			{
			case BarcodeTypes.None:
				return true;
			case BarcodeTypes.Ean13:
			{
				if (Atol10.<>o__45.<>p__4 == null)
				{
					Atol10.<>o__45.<>p__4 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target2 = Atol10.<>o__45.<>p__4.Target;
				CallSite <>p__2 = Atol10.<>o__45.<>p__4;
				object atolDriver2 = this.AtolDriver;
				if (Atol10.<>o__45.<>p__2 == null)
				{
					Atol10.<>o__45.<>p__2 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_BARCODE_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj = Atol10.<>o__45.<>p__2.Target(Atol10.<>o__45.<>p__2, this.AtolDriver);
				if (Atol10.<>o__45.<>p__3 == null)
				{
					Atol10.<>o__45.<>p__3 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_BT_EAN_13", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target2(<>p__2, atolDriver2, obj, Atol10.<>o__45.<>p__3.Target(Atol10.<>o__45.<>p__3, this.AtolDriver));
				break;
			}
			case BarcodeTypes.QrCode:
			{
				if (Atol10.<>o__45.<>p__7 == null)
				{
					Atol10.<>o__45.<>p__7 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target3 = Atol10.<>o__45.<>p__7.Target;
				CallSite <>p__3 = Atol10.<>o__45.<>p__7;
				object atolDriver3 = this.AtolDriver;
				if (Atol10.<>o__45.<>p__5 == null)
				{
					Atol10.<>o__45.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_BARCODE_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj2 = Atol10.<>o__45.<>p__5.Target(Atol10.<>o__45.<>p__5, this.AtolDriver);
				if (Atol10.<>o__45.<>p__6 == null)
				{
					Atol10.<>o__45.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_BT_QR", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target3(<>p__3, atolDriver3, obj2, Atol10.<>o__45.<>p__6.Target(Atol10.<>o__45.<>p__6, this.AtolDriver));
				if (Atol10.<>o__45.<>p__10 == null)
				{
					Atol10.<>o__45.<>p__10 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Action<CallSite, object, object, object> target4 = Atol10.<>o__45.<>p__10.Target;
				CallSite <>p__4 = Atol10.<>o__45.<>p__10;
				object atolDriver4 = this.AtolDriver;
				if (Atol10.<>o__45.<>p__8 == null)
				{
					Atol10.<>o__45.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_ALIGNMENT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj3 = Atol10.<>o__45.<>p__8.Target(Atol10.<>o__45.<>p__8, this.AtolDriver);
				if (Atol10.<>o__45.<>p__9 == null)
				{
					Atol10.<>o__45.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_ALIGNMENT_CENTER", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target4(<>p__4, atolDriver4, obj3, Atol10.<>o__45.<>p__9.Target(Atol10.<>o__45.<>p__9, this.AtolDriver));
				if (Atol10.<>o__45.<>p__12 == null)
				{
					Atol10.<>o__45.<>p__12 = CallSite<Action<CallSite, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				Action<CallSite, object, object, int> target5 = Atol10.<>o__45.<>p__12.Target;
				CallSite <>p__5 = Atol10.<>o__45.<>p__12;
				object atolDriver5 = this.AtolDriver;
				if (Atol10.<>o__45.<>p__11 == null)
				{
					Atol10.<>o__45.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SCALE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				target5(<>p__5, atolDriver5, Atol10.<>o__45.<>p__11.Target(Atol10.<>o__45.<>p__11, this.AtolDriver), 7);
				break;
			}
			}
			if (Atol10.<>o__45.<>p__13 == null)
			{
				Atol10.<>o__45.<>p__13 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "printBarcode", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__45.<>p__13.Target(Atol10.<>o__45.<>p__13, this.AtolDriver);
			this.CheckResult();
			return true;
		}

		// Token: 0x06005414 RID: 21524 RVA: 0x001262F0 File Offset: 0x001244F0
		public bool CutPaper()
		{
			if (Atol10.<>o__46.<>p__0 == null)
			{
				Atol10.<>o__46.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "cut", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__46.<>p__0.Target(Atol10.<>o__46.<>p__0, this.AtolDriver);
			return true;
		}

		// Token: 0x06005415 RID: 21525 RVA: 0x00126354 File Offset: 0x00124554
		public KkmStatus GetStatus()
		{
			KkmStatus status = new KkmStatus
			{
				KkmState = this.GetKkmState()
			};
			if (Atol10.<>o__47.<>p__2 == null)
			{
				Atol10.<>o__47.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__47.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__47.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__47.<>p__0 == null)
			{
				Atol10.<>o__47.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__47.<>p__0.Target(Atol10.<>o__47.<>p__0, this.AtolDriver);
			if (Atol10.<>o__47.<>p__1 == null)
			{
				Atol10.<>o__47.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_SHIFT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__47.<>p__1.Target(Atol10.<>o__47.<>p__1, this.AtolDriver));
			if (Atol10.<>o__47.<>p__3 == null)
			{
				Atol10.<>o__47.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__47.<>p__3.Target(Atol10.<>o__47.<>p__3, this.AtolDriver);
			if (Atol10.<>o__47.<>p__5 == null)
			{
				Atol10.<>o__47.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target2 = Atol10.<>o__47.<>p__5.Target;
			CallSite <>p__2 = Atol10.<>o__47.<>p__5;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__4 == null)
			{
				Atol10.<>o__47.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SHIFT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj2 = target2(<>p__2, atolDriver2, Atol10.<>o__47.<>p__4.Target(Atol10.<>o__47.<>p__4, this.AtolDriver));
			if (obj2 is int)
			{
				switch ((int)obj2)
				{
				case 0:
					status.SessionStatus = SessionStatuses.Close;
					break;
				case 1:
					status.SessionStatus = SessionStatuses.Open;
					break;
				case 2:
					status.SessionStatus = SessionStatuses.OpenMore24Hours;
					break;
				}
			}
			KkmStatus kkmStatus = status;
			if (Atol10.<>o__47.<>p__8 == null)
			{
				Atol10.<>o__47.<>p__8 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target3 = Atol10.<>o__47.<>p__8.Target;
			CallSite <>p__3 = Atol10.<>o__47.<>p__8;
			if (Atol10.<>o__47.<>p__7 == null)
			{
				Atol10.<>o__47.<>p__7 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target4 = Atol10.<>o__47.<>p__7.Target;
			CallSite <>p__4 = Atol10.<>o__47.<>p__7;
			object atolDriver3 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__6 == null)
			{
				Atol10.<>o__47.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SHIFT_NUMBER", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus.SessionNumber = target3(<>p__3, target4(<>p__4, atolDriver3, Atol10.<>o__47.<>p__6.Target(Atol10.<>o__47.<>p__6, this.AtolDriver)));
			KkmStatus kkmStatus2 = status;
			if (Atol10.<>o__47.<>p__11 == null)
			{
				Atol10.<>o__47.<>p__11 = CallSite<Func<CallSite, object, DateTime>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(DateTime), typeof(Atol10)));
			}
			Func<CallSite, object, DateTime> target5 = Atol10.<>o__47.<>p__11.Target;
			CallSite <>p__5 = Atol10.<>o__47.<>p__11;
			if (Atol10.<>o__47.<>p__10 == null)
			{
				Atol10.<>o__47.<>p__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamDateTime", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target6 = Atol10.<>o__47.<>p__10.Target;
			CallSite <>p__6 = Atol10.<>o__47.<>p__10;
			object atolDriver4 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__9 == null)
			{
				Atol10.<>o__47.<>p__9 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATE_TIME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus2.SessionStarted = new DateTime?(target5(<>p__5, target6(<>p__6, atolDriver4, Atol10.<>o__47.<>p__9.Target(Atol10.<>o__47.<>p__9, this.AtolDriver))).AddHours(-24.0));
			if (Atol10.<>o__47.<>p__14 == null)
			{
				Atol10.<>o__47.<>p__14 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target7 = Atol10.<>o__47.<>p__14.Target;
			CallSite <>p__7 = Atol10.<>o__47.<>p__14;
			object atolDriver5 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__12 == null)
			{
				Atol10.<>o__47.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj3 = Atol10.<>o__47.<>p__12.Target(Atol10.<>o__47.<>p__12, this.AtolDriver);
			if (Atol10.<>o__47.<>p__13 == null)
			{
				Atol10.<>o__47.<>p__13 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_RECEIPT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target7(<>p__7, atolDriver5, obj3, Atol10.<>o__47.<>p__13.Target(Atol10.<>o__47.<>p__13, this.AtolDriver));
			if (Atol10.<>o__47.<>p__15 == null)
			{
				Atol10.<>o__47.<>p__15 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__47.<>p__15.Target(Atol10.<>o__47.<>p__15, this.AtolDriver);
			KkmStatus kkmStatus3 = status;
			if (Atol10.<>o__47.<>p__21 == null)
			{
				Atol10.<>o__47.<>p__21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target8 = Atol10.<>o__47.<>p__21.Target;
			CallSite <>p__8 = Atol10.<>o__47.<>p__21;
			if (Atol10.<>o__47.<>p__20 == null)
			{
				Atol10.<>o__47.<>p__20 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Func<CallSite, object, int, object> target9 = Atol10.<>o__47.<>p__20.Target;
			CallSite <>p__9 = Atol10.<>o__47.<>p__20;
			if (Atol10.<>o__47.<>p__17 == null)
			{
				Atol10.<>o__47.<>p__17 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target10 = Atol10.<>o__47.<>p__17.Target;
			CallSite <>p__10 = Atol10.<>o__47.<>p__17;
			object atolDriver6 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__16 == null)
			{
				Atol10.<>o__47.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj4 = target10(<>p__10, atolDriver6, Atol10.<>o__47.<>p__16.Target(Atol10.<>o__47.<>p__16, this.AtolDriver));
			if (Atol10.<>o__47.<>p__19 == null)
			{
				Atol10.<>o__47.<>p__19 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target11 = Atol10.<>o__47.<>p__19.Target;
			CallSite <>p__11 = Atol10.<>o__47.<>p__19;
			if (Atol10.<>o__47.<>p__18 == null)
			{
				Atol10.<>o__47.<>p__18 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_CLOSED", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus3.CheckStatus = (target8(<>p__8, target9(<>p__9, obj4, target11(<>p__11, Atol10.<>o__47.<>p__18.Target(Atol10.<>o__47.<>p__18, this.AtolDriver)))) ? CheckStatuses.Close : CheckStatuses.Open);
			KkmStatus kkmStatus4 = status;
			if (Atol10.<>o__47.<>p__24 == null)
			{
				Atol10.<>o__47.<>p__24 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target12 = Atol10.<>o__47.<>p__24.Target;
			CallSite <>p__12 = Atol10.<>o__47.<>p__24;
			if (Atol10.<>o__47.<>p__23 == null)
			{
				Atol10.<>o__47.<>p__23 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target13 = Atol10.<>o__47.<>p__23.Target;
			CallSite <>p__13 = Atol10.<>o__47.<>p__23;
			object atolDriver7 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__22 == null)
			{
				Atol10.<>o__47.<>p__22 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_NUMBER", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus4.CheckNumber = target12(<>p__12, target13(<>p__13, atolDriver7, Atol10.<>o__47.<>p__22.Target(Atol10.<>o__47.<>p__22, this.AtolDriver))) + 1;
			KkmStatus kkmStatus5 = status;
			if (Atol10.<>o__47.<>p__27 == null)
			{
				Atol10.<>o__47.<>p__27 = CallSite<Func<CallSite, global::System.Type, object, Version>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, Version> target14 = Atol10.<>o__47.<>p__27.Target;
			CallSite <>p__14 = Atol10.<>o__47.<>p__27;
			Type typeFromHandle = typeof(Version);
			if (Atol10.<>o__47.<>p__26 == null)
			{
				Atol10.<>o__47.<>p__26 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, object> target15 = Atol10.<>o__47.<>p__26.Target;
			CallSite <>p__15 = Atol10.<>o__47.<>p__26;
			if (Atol10.<>o__47.<>p__25 == null)
			{
				Atol10.<>o__47.<>p__25 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "version", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus5.DriverVersion = target14(<>p__14, typeFromHandle, target15(<>p__15, Atol10.<>o__47.<>p__25.Target(Atol10.<>o__47.<>p__25, this.AtolDriver)));
			if (Atol10.<>o__47.<>p__30 == null)
			{
				Atol10.<>o__47.<>p__30 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target16 = Atol10.<>o__47.<>p__30.Target;
			CallSite <>p__16 = Atol10.<>o__47.<>p__30;
			object atolDriver8 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__28 == null)
			{
				Atol10.<>o__47.<>p__28 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj5 = Atol10.<>o__47.<>p__28.Target(Atol10.<>o__47.<>p__28, this.AtolDriver);
			if (Atol10.<>o__47.<>p__29 == null)
			{
				Atol10.<>o__47.<>p__29 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target16(<>p__16, atolDriver8, obj5, Atol10.<>o__47.<>p__29.Target(Atol10.<>o__47.<>p__29, this.AtolDriver));
			if (Atol10.<>o__47.<>p__31 == null)
			{
				Atol10.<>o__47.<>p__31 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__47.<>p__31.Target(Atol10.<>o__47.<>p__31, this.AtolDriver);
			KkmStatus kkmStatus6 = status;
			if (Atol10.<>o__47.<>p__34 == null)
			{
				Atol10.<>o__47.<>p__34 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Atol10)));
			}
			Func<CallSite, object, string> target17 = Atol10.<>o__47.<>p__34.Target;
			CallSite <>p__17 = Atol10.<>o__47.<>p__34;
			if (Atol10.<>o__47.<>p__33 == null)
			{
				Atol10.<>o__47.<>p__33 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamString", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target18 = Atol10.<>o__47.<>p__33.Target;
			CallSite <>p__18 = Atol10.<>o__47.<>p__33;
			object atolDriver9 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__32 == null)
			{
				Atol10.<>o__47.<>p__32 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SERIAL_NUMBER", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus6.FactoryNumber = target17(<>p__17, target18(<>p__18, atolDriver9, Atol10.<>o__47.<>p__32.Target(Atol10.<>o__47.<>p__32, this.AtolDriver)));
			KkmStatus kkmStatus7 = status;
			if (Atol10.<>o__47.<>p__37 == null)
			{
				Atol10.<>o__47.<>p__37 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Atol10)));
			}
			Func<CallSite, object, string> target19 = Atol10.<>o__47.<>p__37.Target;
			CallSite <>p__19 = Atol10.<>o__47.<>p__37;
			if (Atol10.<>o__47.<>p__36 == null)
			{
				Atol10.<>o__47.<>p__36 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamString", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target20 = Atol10.<>o__47.<>p__36.Target;
			CallSite <>p__20 = Atol10.<>o__47.<>p__36;
			object atolDriver10 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__35 == null)
			{
				Atol10.<>o__47.<>p__35 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_MODEL_NAME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus7.Model = target19(<>p__19, target20(<>p__20, atolDriver10, Atol10.<>o__47.<>p__35.Target(Atol10.<>o__47.<>p__35, this.AtolDriver)));
			KkmStatus kkmStatus8 = status;
			if (Atol10.<>o__47.<>p__40 == null)
			{
				Atol10.<>o__47.<>p__40 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Atol10)));
			}
			Func<CallSite, object, string> target21 = Atol10.<>o__47.<>p__40.Target;
			CallSite <>p__21 = Atol10.<>o__47.<>p__40;
			if (Atol10.<>o__47.<>p__39 == null)
			{
				Atol10.<>o__47.<>p__39 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamString", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target22 = Atol10.<>o__47.<>p__39.Target;
			CallSite <>p__22 = Atol10.<>o__47.<>p__39;
			object atolDriver11 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__38 == null)
			{
				Atol10.<>o__47.<>p__38 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_UNIT_VERSION", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus8.SoftwareVersion = target21(<>p__21, target22(<>p__22, atolDriver11, Atol10.<>o__47.<>p__38.Target(Atol10.<>o__47.<>p__38, this.AtolDriver)));
			if (Atol10.<>o__47.<>p__43 == null)
			{
				Atol10.<>o__47.<>p__43 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target23 = Atol10.<>o__47.<>p__43.Target;
			CallSite <>p__23 = Atol10.<>o__47.<>p__43;
			object atolDriver12 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__41 == null)
			{
				Atol10.<>o__47.<>p__41 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FN_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj6 = Atol10.<>o__47.<>p__41.Target(Atol10.<>o__47.<>p__41, this.AtolDriver);
			if (Atol10.<>o__47.<>p__42 == null)
			{
				Atol10.<>o__47.<>p__42 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_FNDT_OFD_EXCHANGE_STATUS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target23(<>p__23, atolDriver12, obj6, Atol10.<>o__47.<>p__42.Target(Atol10.<>o__47.<>p__42, this.AtolDriver));
			if (Atol10.<>o__47.<>p__44 == null)
			{
				Atol10.<>o__47.<>p__44 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "fnQueryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__47.<>p__44.Target(Atol10.<>o__47.<>p__44, this.AtolDriver);
			KkmStatus kkmStatus9 = status;
			if (Atol10.<>o__47.<>p__47 == null)
			{
				Atol10.<>o__47.<>p__47 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target24 = Atol10.<>o__47.<>p__47.Target;
			CallSite <>p__24 = Atol10.<>o__47.<>p__47;
			if (Atol10.<>o__47.<>p__46 == null)
			{
				Atol10.<>o__47.<>p__46 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target25 = Atol10.<>o__47.<>p__46.Target;
			CallSite <>p__25 = Atol10.<>o__47.<>p__46;
			object atolDriver13 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__45 == null)
			{
				Atol10.<>o__47.<>p__45 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DOCUMENTS_COUNT", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus9.OfdNotSendDocuments = target24(<>p__24, target25(<>p__25, atolDriver13, Atol10.<>o__47.<>p__45.Target(Atol10.<>o__47.<>p__45, this.AtolDriver)));
			KkmStatus kkmStatus10 = status;
			if (Atol10.<>o__47.<>p__50 == null)
			{
				Atol10.<>o__47.<>p__50 = CallSite<Func<CallSite, object, DateTime?>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(DateTime?), typeof(Atol10)));
			}
			Func<CallSite, object, DateTime?> target26 = Atol10.<>o__47.<>p__50.Target;
			CallSite <>p__26 = Atol10.<>o__47.<>p__50;
			if (Atol10.<>o__47.<>p__49 == null)
			{
				Atol10.<>o__47.<>p__49 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamDateTime", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target27 = Atol10.<>o__47.<>p__49.Target;
			CallSite <>p__27 = Atol10.<>o__47.<>p__49;
			object atolDriver14 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__48 == null)
			{
				Atol10.<>o__47.<>p__48 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATE_TIME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus10.OfdLastSendDateTime = target26(<>p__26, target27(<>p__27, atolDriver14, Atol10.<>o__47.<>p__48.Target(Atol10.<>o__47.<>p__48, this.AtolDriver)));
			if (Atol10.<>o__47.<>p__53 == null)
			{
				Atol10.<>o__47.<>p__53 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target28 = Atol10.<>o__47.<>p__53.Target;
			CallSite <>p__28 = Atol10.<>o__47.<>p__53;
			object atolDriver15 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__51 == null)
			{
				Atol10.<>o__47.<>p__51 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FN_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj7 = Atol10.<>o__47.<>p__51.Target(Atol10.<>o__47.<>p__51, this.AtolDriver);
			if (Atol10.<>o__47.<>p__52 == null)
			{
				Atol10.<>o__47.<>p__52 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_FNDT_VALIDITY", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target28(<>p__28, atolDriver15, obj7, Atol10.<>o__47.<>p__52.Target(Atol10.<>o__47.<>p__52, this.AtolDriver));
			if (Atol10.<>o__47.<>p__54 == null)
			{
				Atol10.<>o__47.<>p__54 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "fnQueryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__47.<>p__54.Target(Atol10.<>o__47.<>p__54, this.AtolDriver);
			KkmStatus kkmStatus11 = status;
			if (Atol10.<>o__47.<>p__57 == null)
			{
				Atol10.<>o__47.<>p__57 = CallSite<Func<CallSite, object, DateTime>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(DateTime), typeof(Atol10)));
			}
			Func<CallSite, object, DateTime> target29 = Atol10.<>o__47.<>p__57.Target;
			CallSite <>p__29 = Atol10.<>o__47.<>p__57;
			if (Atol10.<>o__47.<>p__56 == null)
			{
				Atol10.<>o__47.<>p__56 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamDateTime", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target30 = Atol10.<>o__47.<>p__56.Target;
			CallSite <>p__30 = Atol10.<>o__47.<>p__56;
			object atolDriver16 = this.AtolDriver;
			if (Atol10.<>o__47.<>p__55 == null)
			{
				Atol10.<>o__47.<>p__55 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATE_TIME", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus11.FnDateEnd = target29(<>p__29, target30(<>p__30, atolDriver16, Atol10.<>o__47.<>p__55.Target(Atol10.<>o__47.<>p__55, this.AtolDriver)));
			if (Atol10.<>o__47.<>p__59 == null)
			{
				Atol10.<>o__47.<>p__59 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target31 = Atol10.<>o__47.<>p__59.Target;
			CallSite <>p__31 = Atol10.<>o__47.<>p__59;
			if (Atol10.<>o__47.<>p__58 == null)
			{
				Atol10.<>o__47.<>p__58 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			int resultCode = target31(<>p__31, Atol10.<>o__47.<>p__58.Target(Atol10.<>o__47.<>p__58, this.AtolDriver));
			if (resultCode == 82)
			{
				LogHelper.Debug("Ошибка 82. Пытаемся закрыть прошлый документ");
				if (Atol10.<>o__47.<>p__60 == null)
				{
					Atol10.<>o__47.<>p__60 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "closeReceipt", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__47.<>p__60.Target(Atol10.<>o__47.<>p__60, this.AtolDriver);
				if (Atol10.<>o__47.<>p__61 == null)
				{
					Atol10.<>o__47.<>p__61 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "checkDocumentClosed", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__47.<>p__61.Target(Atol10.<>o__47.<>p__61, this.AtolDriver);
				if (Atol10.<>o__47.<>p__63 == null)
				{
					Atol10.<>o__47.<>p__63 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
				}
				Func<CallSite, object, int> target32 = Atol10.<>o__47.<>p__63.Target;
				CallSite <>p__32 = Atol10.<>o__47.<>p__63;
				if (Atol10.<>o__47.<>p__62 == null)
				{
					Atol10.<>o__47.<>p__62 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				LogHelper.Debug("Результат закрытия: " + target32(<>p__32, Atol10.<>o__47.<>p__62.Target(Atol10.<>o__47.<>p__62, this.AtolDriver)).ToString());
			}
			return status;
		}

		// Token: 0x06005416 RID: 21526 RVA: 0x0012788C File Offset: 0x00125A8C
		public KkmStatus GetShortStatus()
		{
			KkmStatus status = new KkmStatus
			{
				KkmState = this.GetKkmState()
			};
			if (Atol10.<>o__48.<>p__2 == null)
			{
				Atol10.<>o__48.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__48.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__48.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__48.<>p__0 == null)
			{
				Atol10.<>o__48.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__48.<>p__0.Target(Atol10.<>o__48.<>p__0, this.AtolDriver);
			if (Atol10.<>o__48.<>p__1 == null)
			{
				Atol10.<>o__48.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_SHIFT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__48.<>p__1.Target(Atol10.<>o__48.<>p__1, this.AtolDriver));
			if (Atol10.<>o__48.<>p__3 == null)
			{
				Atol10.<>o__48.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__48.<>p__3.Target(Atol10.<>o__48.<>p__3, this.AtolDriver);
			if (Atol10.<>o__48.<>p__5 == null)
			{
				Atol10.<>o__48.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target2 = Atol10.<>o__48.<>p__5.Target;
			CallSite <>p__2 = Atol10.<>o__48.<>p__5;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__48.<>p__4 == null)
			{
				Atol10.<>o__48.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_SHIFT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj2 = target2(<>p__2, atolDriver2, Atol10.<>o__48.<>p__4.Target(Atol10.<>o__48.<>p__4, this.AtolDriver));
			if (obj2 is int)
			{
				switch ((int)obj2)
				{
				case 0:
					status.SessionStatus = SessionStatuses.Close;
					break;
				case 1:
					status.SessionStatus = SessionStatuses.Open;
					break;
				case 2:
					status.SessionStatus = SessionStatuses.OpenMore24Hours;
					break;
				}
			}
			if (Atol10.<>o__48.<>p__8 == null)
			{
				Atol10.<>o__48.<>p__8 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target3 = Atol10.<>o__48.<>p__8.Target;
			CallSite <>p__3 = Atol10.<>o__48.<>p__8;
			object atolDriver3 = this.AtolDriver;
			if (Atol10.<>o__48.<>p__6 == null)
			{
				Atol10.<>o__48.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj3 = Atol10.<>o__48.<>p__6.Target(Atol10.<>o__48.<>p__6, this.AtolDriver);
			if (Atol10.<>o__48.<>p__7 == null)
			{
				Atol10.<>o__48.<>p__7 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_DT_RECEIPT_STATE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target3(<>p__3, atolDriver3, obj3, Atol10.<>o__48.<>p__7.Target(Atol10.<>o__48.<>p__7, this.AtolDriver));
			if (Atol10.<>o__48.<>p__9 == null)
			{
				Atol10.<>o__48.<>p__9 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__48.<>p__9.Target(Atol10.<>o__48.<>p__9, this.AtolDriver);
			KkmStatus kkmStatus = status;
			if (Atol10.<>o__48.<>p__15 == null)
			{
				Atol10.<>o__48.<>p__15 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target4 = Atol10.<>o__48.<>p__15.Target;
			CallSite <>p__4 = Atol10.<>o__48.<>p__15;
			if (Atol10.<>o__48.<>p__14 == null)
			{
				Atol10.<>o__48.<>p__14 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Func<CallSite, object, int, object> target5 = Atol10.<>o__48.<>p__14.Target;
			CallSite <>p__5 = Atol10.<>o__48.<>p__14;
			if (Atol10.<>o__48.<>p__11 == null)
			{
				Atol10.<>o__48.<>p__11 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target6 = Atol10.<>o__48.<>p__11.Target;
			CallSite <>p__6 = Atol10.<>o__48.<>p__11;
			object atolDriver4 = this.AtolDriver;
			if (Atol10.<>o__48.<>p__10 == null)
			{
				Atol10.<>o__48.<>p__10 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_RECEIPT_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj4 = target6(<>p__6, atolDriver4, Atol10.<>o__48.<>p__10.Target(Atol10.<>o__48.<>p__10, this.AtolDriver));
			if (Atol10.<>o__48.<>p__13 == null)
			{
				Atol10.<>o__48.<>p__13 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target7 = Atol10.<>o__48.<>p__13.Target;
			CallSite <>p__7 = Atol10.<>o__48.<>p__13;
			if (Atol10.<>o__48.<>p__12 == null)
			{
				Atol10.<>o__48.<>p__12 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_RT_CLOSED", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			kkmStatus.CheckStatus = (target4(<>p__4, target5(<>p__5, obj4, target7(<>p__7, Atol10.<>o__48.<>p__12.Target(Atol10.<>o__48.<>p__12, this.AtolDriver)))) ? CheckStatuses.Close : CheckStatuses.Open);
			if (Atol10.<>o__48.<>p__17 == null)
			{
				Atol10.<>o__48.<>p__17 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
			}
			Func<CallSite, object, int> target8 = Atol10.<>o__48.<>p__17.Target;
			CallSite <>p__8 = Atol10.<>o__48.<>p__17;
			if (Atol10.<>o__48.<>p__16 == null)
			{
				Atol10.<>o__48.<>p__16 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			int resultCode = target8(<>p__8, Atol10.<>o__48.<>p__16.Target(Atol10.<>o__48.<>p__16, this.AtolDriver));
			if (resultCode == 82)
			{
				LogHelper.Debug("Ошибка 82. Пытаемся закрыть прошлый документ");
				if (Atol10.<>o__48.<>p__18 == null)
				{
					Atol10.<>o__48.<>p__18 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "closeReceipt", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__48.<>p__18.Target(Atol10.<>o__48.<>p__18, this.AtolDriver);
				if (Atol10.<>o__48.<>p__19 == null)
				{
					Atol10.<>o__48.<>p__19 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "checkDocumentClosed", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Atol10.<>o__48.<>p__19.Target(Atol10.<>o__48.<>p__19, this.AtolDriver);
				if (Atol10.<>o__48.<>p__21 == null)
				{
					Atol10.<>o__48.<>p__21 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Atol10)));
				}
				Func<CallSite, object, int> target9 = Atol10.<>o__48.<>p__21.Target;
				CallSite <>p__9 = Atol10.<>o__48.<>p__21;
				if (Atol10.<>o__48.<>p__20 == null)
				{
					Atol10.<>o__48.<>p__20 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "errorCode", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				LogHelper.Debug("Результат закрытия: " + target9(<>p__9, Atol10.<>o__48.<>p__20.Target(Atol10.<>o__48.<>p__20, this.AtolDriver)).ToString());
			}
			return status;
		}

		// Token: 0x06005417 RID: 21527 RVA: 0x00128024 File Offset: 0x00126224
		public bool OpenCashDrawer()
		{
			if (Atol10.<>o__49.<>p__0 == null)
			{
				Atol10.<>o__49.<>p__0 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "openDrawer", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__49.<>p__0.Target(Atol10.<>o__49.<>p__0, this.AtolDriver);
			return true;
		}

		// Token: 0x06005418 RID: 21528 RVA: 0x00128088 File Offset: 0x00126288
		public GlobalDictionaries.Devices.FfdVersions GetFfdVersion()
		{
			if (Atol10.<>o__50.<>p__2 == null)
			{
				Atol10.<>o__50.<>p__2 = CallSite<Action<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Action<CallSite, object, object, object> target = Atol10.<>o__50.<>p__2.Target;
			CallSite <>p__ = Atol10.<>o__50.<>p__2;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__50.<>p__0 == null)
			{
				Atol10.<>o__50.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FN_DATA_TYPE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj = Atol10.<>o__50.<>p__0.Target(Atol10.<>o__50.<>p__0, this.AtolDriver);
			if (Atol10.<>o__50.<>p__1 == null)
			{
				Atol10.<>o__50.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_FNDT_FFD_VERSIONS", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			target(<>p__, atolDriver, obj, Atol10.<>o__50.<>p__1.Target(Atol10.<>o__50.<>p__1, this.AtolDriver));
			if (Atol10.<>o__50.<>p__3 == null)
			{
				Atol10.<>o__50.<>p__3 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "queryData", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__50.<>p__3.Target(Atol10.<>o__50.<>p__3, this.AtolDriver);
			if (Atol10.<>o__50.<>p__5 == null)
			{
				Atol10.<>o__50.<>p__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamInt", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target2 = Atol10.<>o__50.<>p__5.Target;
			CallSite <>p__2 = Atol10.<>o__50.<>p__5;
			object atolDriver2 = this.AtolDriver;
			if (Atol10.<>o__50.<>p__4 == null)
			{
				Atol10.<>o__50.<>p__4 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_FFD_VERSION", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object ffd = target2(<>p__2, atolDriver2, Atol10.<>o__50.<>p__4.Target(Atol10.<>o__50.<>p__4, this.AtolDriver));
			if (ffd is int)
			{
				switch ((int)ffd)
				{
				case 0:
					return GlobalDictionaries.Devices.FfdVersions.OfflineKkm;
				case 1:
					return GlobalDictionaries.Devices.FfdVersions.Ffd105;
				case 2:
					return GlobalDictionaries.Devices.FfdVersions.Ffd110;
				case 3:
					return GlobalDictionaries.Devices.FfdVersions.Ffd120;
				}
			}
			return GlobalDictionaries.Devices.FfdVersions.OfflineKkm;
		}

		// Token: 0x06005419 RID: 21529 RVA: 0x001282CF File Offset: 0x001264CF
		public void FeedPaper(int lines)
		{
		}

		// Token: 0x0600541A RID: 21530 RVA: 0x001282D1 File Offset: 0x001264D1
		public bool EndPrintOldCheck()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600541B RID: 21531 RVA: 0x001282D8 File Offset: 0x001264D8
		public string PrepareMarkCodeForFfd120(string code)
		{
			return DataMatrixHelper.ReplaceSomeCharsToFNC1(code);
		}

		// Token: 0x0600541C RID: 21532 RVA: 0x001282E0 File Offset: 0x001264E0
		private void GetSalesNotice(string info)
		{
			if (info.IsNullOrEmpty() || new ConfigsRepository<Devices>().Get().CheckPrinter.FiscalKkm.FfdVersion != GlobalDictionaries.Devices.FfdVersions.Ffd120)
			{
				return;
			}
			if (Atol10.<>o__54.<>p__0 == null)
			{
				Atol10.<>o__54.<>p__0 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Atol10.<>o__54.<>p__0.Target(Atol10.<>o__54.<>p__0, this.AtolDriver, 1262, "030");
			if (Atol10.<>o__54.<>p__1 == null)
			{
				Atol10.<>o__54.<>p__1 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Atol10.<>o__54.<>p__1.Target(Atol10.<>o__54.<>p__1, this.AtolDriver, 1263, "21.11.2023");
			if (Atol10.<>o__54.<>p__2 == null)
			{
				Atol10.<>o__54.<>p__2 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			Atol10.<>o__54.<>p__2.Target(Atol10.<>o__54.<>p__2, this.AtolDriver, 1264, "1944");
			if (Atol10.<>o__54.<>p__3 == null)
			{
				Atol10.<>o__54.<>p__3 = CallSite<Action<CallSite, object, int, string>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "setParam", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
				}));
			}
			Atol10.<>o__54.<>p__3.Target(Atol10.<>o__54.<>p__3, this.AtolDriver, 1265, info);
			if (Atol10.<>o__54.<>p__4 == null)
			{
				Atol10.<>o__54.<>p__4 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "utilFormTlv", null, typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Atol10.<>o__54.<>p__4.Target(Atol10.<>o__54.<>p__4, this.AtolDriver);
			if (Atol10.<>o__54.<>p__7 == null)
			{
				Atol10.<>o__54.<>p__7 = CallSite<Func<CallSite, object, byte[]>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(byte[]), typeof(Atol10)));
			}
			Func<CallSite, object, byte[]> target = Atol10.<>o__54.<>p__7.Target;
			CallSite <>p__ = Atol10.<>o__54.<>p__7;
			if (Atol10.<>o__54.<>p__6 == null)
			{
				Atol10.<>o__54.<>p__6 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "getParamByteArray", null, typeof(Atol10), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, object, object, object> target2 = Atol10.<>o__54.<>p__6.Target;
			CallSite <>p__2 = Atol10.<>o__54.<>p__6;
			object atolDriver = this.AtolDriver;
			if (Atol10.<>o__54.<>p__5 == null)
			{
				Atol10.<>o__54.<>p__5 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LIBFPTR_PARAM_TAG_VALUE", typeof(Atol10), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			this._industryInfo = target(<>p__, target2(<>p__2, atolDriver, Atol10.<>o__54.<>p__5.Target(Atol10.<>o__54.<>p__5, this.AtolDriver)));
		}

		// Token: 0x04001CDF RID: 7391
		private CheckData _checkData;

		// Token: 0x04001CE0 RID: 7392
		private byte[] _industryInfo;
	}
}
